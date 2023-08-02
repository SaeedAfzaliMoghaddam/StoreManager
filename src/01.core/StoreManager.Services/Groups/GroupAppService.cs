using StoreManager.Entities;
using StoreManager.Services.Contracts;
using StoreManager.Services.Groups.Contracts;
using StoreManager.Services.Groups.Contracts.Dto;
using StoreManager.Services.Groups.Exceptions;

namespace StoreManager.Services.Groups
{
    public class GroupAppService : GroupService
    {
        private readonly GroupRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public GroupAppService(GroupRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
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
    }
}