using Sieve.Attributes;

namespace Advanced_Repository_Operations___Asynchronous_Programming.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }   
        public decimal Price { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
