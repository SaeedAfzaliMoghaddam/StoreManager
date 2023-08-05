using Microsoft.EntityFrameworkCore;
using StoreManager.Entities;
using StoreManager.Services.ProductEntrances.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Persistence.EF.ProductEntrances
{
    public class EFProductEntranceRepository : ProductEntranceRepository
    {
        private readonly DbSet<ProductEntrance> _productEntrances;
        public EFProductEntranceRepository(EFDataContext context)
        {
            _productEntrances = context.Set<ProductEntrance>();
        }
        public void Add(ProductEntrance productEntrance)
        {
            _productEntrances.Add(productEntrance);
        }
    }
}
