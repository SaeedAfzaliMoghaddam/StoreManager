namespace StoreManager.Entities
{
    public class Product
    {
        public Product()
        {
            ProductEntrances = new HashSet<ProductEntrance>();
            ProductSaleBills = new HashSet<ProductSaleBill>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int GroupId { get; set; }
        public int MinimumInventory { get; set; }
        public int? Inventory { get; set; }
        public ProductStatus Status { get; set; }
        public Group Group { get; set; }
        public HashSet<ProductEntrance> ProductEntrances { get; set; }
        public HashSet<ProductSaleBill> ProductSaleBills { get; set; }

    }
}

public enum ProductStatus
{
    OutOfStocks = 0,
    ReadyToOrder,
    InStock
}

