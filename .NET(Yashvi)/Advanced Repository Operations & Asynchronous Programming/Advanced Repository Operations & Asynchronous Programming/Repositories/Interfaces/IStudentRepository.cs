public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync(StudentQueryParameters parameters);
    Task<Student?> GetByIdAsync(int id);
    Task AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(int id);
}
