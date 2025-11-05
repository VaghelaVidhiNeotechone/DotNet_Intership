namespace Code_First_Approach.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }

        public int TeacherId { get; set; }       
        public Teacher Teacher { get; set; }    

        public List<StudentCourse> StudentCourses { get; set; }
    }
}
