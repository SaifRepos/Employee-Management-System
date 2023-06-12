using System.ComponentModel.DataAnnotations;

namespace Employe_Management_System.Dto
{
    public class DepartmentDto
    {
        [Required]
        public string Name { get; set; }
    }
}
