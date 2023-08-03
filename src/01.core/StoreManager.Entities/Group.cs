namespace StoreManager.Entities
{
    public class Group
    {
        public Group()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<Product> Products { get; set; }
        
    }
}