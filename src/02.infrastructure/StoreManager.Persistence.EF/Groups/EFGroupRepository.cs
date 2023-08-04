using Microsoft.EntityFrameworkCore;
using StoreManager.Entities;
using StoreManager.Services.Groups.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Persistence.EF.Groups
{
    public class EFGroupRepository : GroupRepository
    {
        private readonly DbSet<Group> _groups;
        public EFGroupRepository(EFDataContext context)
        {
            _groups = context.Set<Group>();
        }
        public void Add(Group group)
        {
            _groups.Add(group);
        }

        public void Delete(Group group)
        {
            _groups.Remove(group);
        }

        public Group FindById(int id)
        {
            var group = _groups.FirstOrDefault(_ => _.Id == id);
            return group;
        }

        public bool IdExist(int id)
        {
            return _groups.Any(_ => _.Id == id);
        }

        public bool NameExist(string name)
        {
            return _groups.Any(_=>_.Name == name);
        }

        public bool ProductNameExist(string name)
        {
            return _groups.Any(_ => _.Products.Select(_ => _.Title == name).Any());
        }
    }
}
