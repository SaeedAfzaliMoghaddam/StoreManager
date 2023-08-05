using Microsoft.EntityFrameworkCore;
using StoreManager.Entities;
using StoreManager.Services.ProductSaleBills.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Persistence.EF.ProductSaleBills
{
    public class EFProductSaleBillRepository : ProductSaleBillRepository
    {
        private readonly DbSet<ProductSaleBill> _productSaleBills;

        public EFProductSaleBillRepository(EFDataContext context)
        {
            _productSaleBills = context.Set<ProductSaleBill>();
        }

        public void Add(ProductSaleBill productSaleBill)
        {
            _productSaleBills.Add(productSaleBill);
        }
    }
}
