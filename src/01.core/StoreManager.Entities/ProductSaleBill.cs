namespace StoreManager.Entities
{
    public class ProductSaleBill
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Count { get; set; }
        public string BillNumber { get; set; }
        public string DateTime { get; set; }
        public int ProductEntranceId { get; set; }
        public ProductEntrance ProductEntrance { get; set; }
        public AccountingDocument AccountingDocument { get; set; }


        
    }
}