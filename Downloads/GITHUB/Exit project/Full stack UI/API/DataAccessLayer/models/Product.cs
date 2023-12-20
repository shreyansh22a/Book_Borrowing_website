namespace DataAccessLayer.models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }

        public int AvailableQuantity { get; set; }

        public string Image { get; set; }
        public decimal Price { get; set; }
        public long Discount { get; set; }
        public string Specification { get; set; }
    }
}
