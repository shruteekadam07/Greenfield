namespace Catalog.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return ProductId + " " + Title + " " + Description;
        }
    }
}
