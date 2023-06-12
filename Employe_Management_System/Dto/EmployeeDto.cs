using System.ComponentModel.DataAnnotations;

namespace Employe_Management_System.Dto
{
    public class EmployeeDto

    {
        [MaxLength(30)]
        [Required]

        public string Name { get; set; }
        [Range(21, 100, ErrorMessage = "Age should be between 21-100")]
        [Required]
        public int Age { get; set; }
        [Required]
        public int Department_Id { get; set; }
        [Required(ErrorMessage ="Salary not entered")]
        public double Salary { get; set; }
    }
}
