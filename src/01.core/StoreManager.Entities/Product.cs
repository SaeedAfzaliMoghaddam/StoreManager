namespace StoreManager.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GroupId { get; set; }
        public int MinimumInventory { get; set; }
        public int? Inventory { get; set; }
        public ProductStatus Status { get; set; }
        public Group Group { get; set; }
        public HashSet<ProductEntrance> ProductEntrances { get; set;}

    }
}

public enum ProductStatus
{
    OutOfStocks = 0,
    ReadyToOrder,
    InStock
}

