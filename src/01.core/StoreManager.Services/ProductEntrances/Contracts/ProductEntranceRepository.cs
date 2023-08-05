using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Services.ProductEntrances.Contracts
{
    public interface ProductEntranceRepository
    {
        void Add(ProductEntrance productEntrance);
        
    }
}
