using System.ComponentModel.DataAnnotations;

namespace ASPCore_Assignment2.Models.DTO
{
    public class UpdateEmployeeDto
    {
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [Range(21, 100)]
        public int Age { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
    }
}
