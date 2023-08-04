using StoreManager.Entities;
using StoreManager.Services.Contracts;
using StoreManager.Services.Groups.Contracts;
using StoreManager.Services.Groups.Exceptions;
using StoreManager.Services.Products.Contracts;
using StoreManager.Services.Products.Contracts.Dto;
using StoreManager.Services.Products.Exceptions;

namespace StoreManager.Services.Products
{
    public class ProductAppService : ProductService
    {
        private readonly ProductRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly GroupRepository _groupRepository;  
        public ProductAppService
            (
            ProductRepository repository,
            UnitOfWork unitOfWork,
            GroupRepository groupRepository
            
            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _groupRepository = groupRepository;
        }

        public void Define(AddProductsDto dto)
        {
            var productExistInGroup = _groupRepository.ProductNameExist(dto.Title);
            if (productExistInGroup)
            {
                throw new DublicateProductTitleException();
            }
            var groupExist = _groupRepository.IdExist(dto.GroupId);
            if (!groupExist)
            {
                throw new GroupNotFoundException();
            }
            var product = new Product
            {
                Title = dto.Title,
                GroupId = dto.GroupId,
                MinimumInventory = dto.MinimumInventory,
                Status = dto.Status,
                Inventory = dto.Inventory,

            };

            _repository.Add(product);
            _unitOfWork.Complete();
        }
    }
}
