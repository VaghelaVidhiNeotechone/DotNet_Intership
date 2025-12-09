namespace GymApi.DTOs
{
    public class UpdateGymUserDto
    {
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }   // <-- MUST exist
        public int Age { get; set; }        // <-- MUST exist
    }
}
