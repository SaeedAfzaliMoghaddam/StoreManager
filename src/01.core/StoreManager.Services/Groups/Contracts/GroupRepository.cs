using StoreManager.Entities;

namespace StoreManager.Services.Groups.Contracts
{
    public interface GroupRepository
    {
        void Add(Group group);
        bool NameExist(string name);
        void Delete(Group group);
        Group FindById(int id);
        bool IdExist(int id);
        bool ProductNameExist(string name);



    }
}
