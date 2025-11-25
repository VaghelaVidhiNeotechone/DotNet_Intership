namespace Code_First_Approach.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }
    }
}
