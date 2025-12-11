namespace CRUD_Operations_with_the_Repository_Pattern.Models
{
    public class Product
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
