using System.ComponentModel.DataAnnotations;

namespace ASPCore_Assignment2.Models.DTO
{
    public class UpdateDepartmentDto
    {
        [Required(ErrorMessage = "Department Name is Missing")]
        [MaxLength(50, ErrorMessage = "maximum 50 characters allowed")]
        public string Name { get; set; }
    }
}
