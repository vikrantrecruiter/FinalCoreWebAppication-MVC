using System.ComponentModel.DataAnnotations;

namespace SystemEmplyee.Models
{
    public class DepartmentDbModel
    {
        public int DepartmentId { get; set; }

        [Display(Name ="Department")]
        public string? DepartmentName { get; set; }

    }
}
