namespace Employee.Application.Employee.Dto
{
    public class GetEmployeeDto
    {
        public Guid EmployeeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
    }
}
