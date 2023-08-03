using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.TestTools.Factories.Products
{
    public static class ProductFactory
    {
        public static Product Generate(string title, int groupId)
        {
            var product = new Product
            {
                Title = title,
                GroupId = groupId,
            };
            return product;
        }
    }
}
