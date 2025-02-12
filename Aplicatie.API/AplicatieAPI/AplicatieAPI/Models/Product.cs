namespace AplicatieAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name {  get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }
        public required string Description { get; set; }

    }
}
