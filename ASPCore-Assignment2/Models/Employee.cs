using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCore_Assignment2.Models
{
    public class Employee
    {
        [DefaultValue("newid")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public double Salary { get; set; }
        
        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

        
    }
}
