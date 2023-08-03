using StoreManager.Entities;
using StoreManager.Services.Contracts;
using StoreManager.Services.Groups.Contracts;
using StoreManager.Services.Groups.Contracts.Dto;
using StoreManager.Services.Groups.Exceptions;
using StoreManager.Services.Products.Contracts;

namespace StoreManager.Services.Groups
{
    public class GroupAppService : GroupService
    {
        private readonly GroupRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _productRepository;

        public GroupAppService
            (GroupRepository repository,
            UnitOfWork unitOfWork,
            ProductRepository productRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public void Define(AddGroupsDto dto)
        {
            var nameIsExist = _repository.NameExist(dto.Name);
            if (nameIsExist)
            {
                throw new DublicateGroupNameException();
            }
            var group = new Group
            {
                Name = dto.Name,
            };

            _repository.Add(group);
            _unitOfWork.Complete();

        }

        public void Delete(DeleteGroupsDto dto)
        {
            var group = _repository.FindById(dto.Id);
            var groupHaveProducts = _productRepository.IsAsseignedToGroup(dto.Id);
            if (groupHaveProducts)
            {
                throw new GroupHasProductsException();
            }
            else if (group == null)
            {
                throw new GroupNotFoundException();
            }

            _repository.Delete(group);
            _unitOfWork.Complete();
        }
    }
}
