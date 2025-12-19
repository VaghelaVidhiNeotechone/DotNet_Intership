using Microsoft.EntityFrameworkCore;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync(StudentQueryParameters parameters)
    {
        IQueryable<Student> query = _context.Students;

        // Filtering
        if (!string.IsNullOrEmpty(parameters.Department))
        {
            query = query.Where(s => s.Department == parameters.Department);
        }

        // Sorting
        query = parameters.SortBy switch
        {
            "marks" => parameters.IsDescending
                ? query.OrderByDescending(s => s.Marks)
                : query.OrderBy(s => s.Marks),

            "name" => parameters.IsDescending
                ? query.OrderByDescending(s => s.Name)
                : query.OrderBy(s => s.Name),

            _ => query.OrderBy(s => s.Id)
        };

        // Pagination
        return await query
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
