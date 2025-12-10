namespace CRUD_Operations_with_the_Repository_Pattern.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

    }
}
