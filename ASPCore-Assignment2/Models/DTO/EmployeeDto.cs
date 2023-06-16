namespace ASPCore_Assignment2.Models.DTO
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public double Salary { get; set; }

        public Guid DepartmentId { get; set; }

     

    }
}
