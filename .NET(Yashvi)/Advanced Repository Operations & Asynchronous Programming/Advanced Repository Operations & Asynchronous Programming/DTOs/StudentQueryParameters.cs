public class StudentQueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;

    public string? Department { get; set; }

    public string? SortBy { get; set; } // name, marks
    public bool IsDescending { get; set; } = false;
}
