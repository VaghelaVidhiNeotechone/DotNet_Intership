namespace Advanced_Repository_Techniques.Models
{
    public abstract class SoftDeleteEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}
