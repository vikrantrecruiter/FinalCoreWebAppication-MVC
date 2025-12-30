using System.ComponentModel.DataAnnotations;

namespace SystemEmplyee.Models
{
    public class EmployeeDbModel
    {
        public int Id { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage ="The field is required.")]
        public string? Name { get; set; }

        [Display(Name="Email")]
        [Required(ErrorMessage ="The field is required.")]
        public string? Email { get; set; }

        [Display(Name="Phone")]
        [Required(ErrorMessage ="The field is required.")]
        public string? Phone { get; set; }
       
        [Display(Name = "Country")]
        [Required(ErrorMessage = "The field is required.")]
        public int CountId { get; set; }

        [Display(Name ="Country Name")]
        public string? Country { get; set; }


        [Display(Name = "State")]
        [Required(ErrorMessage = "The field is required.")]
        public int StatId { get; set; }

        [Display(Name="State Name")]
        public string? State { get; set; }


        [Display(Name = "City")]
        [Required(ErrorMessage = "The field is required.")]
        public int CityId { get; set; }


        [Display(Name ="City Name")]
        
        public string? City { get; set; }


        [Display(Name="DOB")]
        [Required(ErrorMessage ="The field is required.")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Display(Name="Salary")]
        [Required(ErrorMessage ="The field is required.")]
        public Decimal Salary { get; set; }

        [Display(Name="Department")]
        [Required(ErrorMessage ="The field is required.")]
        public int? Dept { get; set; }

        [Display(Name="Department")]
        public string? Department { get; set; }

        [Display(Name = "Photo")]
        [Required(ErrorMessage = "The field is required.")]
        public IFormFile? photoFile { get; set; }

        public string? Photo { get; set; }



    }
}
