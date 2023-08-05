using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Entities
{
    public class AccountingDocument
    {
        public int Id { get; set; }
        public string BillNumber { get; set; }
        public int DocumentNumber { get; set; }
        public string DateTime { get; set; }
        public int BillPrice { get; set; }
        public int ProductSaleBillId { get; set; }
        public ProductSaleBill ProductSaleBill { get; set; }

    }
}
