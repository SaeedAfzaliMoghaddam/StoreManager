using StoreManager.Services.Groups.Contracts.Dto;

namespace StoreManager.Services.Groups.Contracts
{
    public interface GroupService
    {
        void Define(AddGroupsDto dto);
    }
}