using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Entities
{
    public class ProductEntrance
    {
        public ProductEntrance()
        {
            ProductSaleBills = new HashSet<ProductSaleBill>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string DateTime { get; set; }
        public int Count { get; set; }
        public string FactorNumber { get; set; }
        public string ProductCompanyName { get; set; }
        public Product Product { get; set; }
        public HashSet<ProductSaleBill> ProductSaleBills { get; set; }

    }
}
