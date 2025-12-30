using System.ComponentModel.DataAnnotations;

namespace SystemEmplyee.Models
{
    public class CityDbModel
    {

        public int CityId { get; set; }

        [Display(Name ="City Name")]
        public string CityName { get; set; }

        public int StatId { get; set; }

    }
}
