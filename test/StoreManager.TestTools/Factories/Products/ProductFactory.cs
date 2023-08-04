using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StoreManager.TestTools.Factories.Products
{
    public static class ProductFactory
    {
        public static Product Generate
            (
            string title, int groupId,
            int minimumInventory, ProductStatus status,
            int inventory
            )
        {
            var product = new Product
            {
                Title = title,
                GroupId = groupId,
                MinimumInventory = minimumInventory,
                Status = status,
                Inventory = inventory
            };
            return product;
        }
    }
}
