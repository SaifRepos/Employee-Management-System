using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employe_Management_System.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public int Department_Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
