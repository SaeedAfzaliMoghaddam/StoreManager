namespace StoreManager.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}

