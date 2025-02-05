namespace Employee.Core.Employee
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }

        public required virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; } = string.Empty;

        public required virtual string LastName { get; set; }

        public virtual uint Age { get; set; }

        public required virtual string Title { get; set; }
    }
}
