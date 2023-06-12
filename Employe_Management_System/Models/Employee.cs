using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employe_Management_System.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]

        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(21, 100)]
        [Required]
        public int Age { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int Department_Id { get; set; }
        [Required]
        public double Salary { get; set; }

        public Department Department { get; set; }
    }
}
