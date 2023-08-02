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

        public bool NameExist(string name)
        {
            return _groups.Any(_=>_.Name == name);
        }
    }
}
