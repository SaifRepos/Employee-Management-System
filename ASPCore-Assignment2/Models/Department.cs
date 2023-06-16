using System.ComponentModel;

namespace ASPCore_Assignment2.Models
{
    public class Department
    {
        [DefaultValue("newid")]
        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}
