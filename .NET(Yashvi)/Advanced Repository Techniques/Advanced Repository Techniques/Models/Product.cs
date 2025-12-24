public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
}