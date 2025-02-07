namespace Employee.Application.Employee.Dto
{
    public class GetEmployeeForViewOrUpdateDto
    {
        public Guid? Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public uint Age { get; set; } = 18;

        public string Title { get; set; } = string.Empty;
    }
}
