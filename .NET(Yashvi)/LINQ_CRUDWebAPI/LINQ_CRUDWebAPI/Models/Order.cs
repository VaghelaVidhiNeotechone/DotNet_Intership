namespace LINQ.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
