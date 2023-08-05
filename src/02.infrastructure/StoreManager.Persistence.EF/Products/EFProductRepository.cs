using Microsoft.EntityFrameworkCore;
using StoreManager.Entities;
using StoreManager.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Persistence.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly DbSet<Product> _products;
        public EFProductRepository(EFDataContext context)
        {
            _products = context.Set<Product>();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public Product FindById(int id)
        {
            return _products.Where(_ => _.Id == id).FirstOrDefault();
        }

        public bool IsAsseignedToGroup(int id)
        {
            return _products.Any(_=>_.GroupId == id);
        }

        public void Update(Product product)
        {
            _products.Update(product);
        }
    }
}
