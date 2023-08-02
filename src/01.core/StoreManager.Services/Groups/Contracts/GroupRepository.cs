using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Services.Groups.Contracts
{
    public interface GroupRepository
    {
        void Add(Group group);
    }
}
