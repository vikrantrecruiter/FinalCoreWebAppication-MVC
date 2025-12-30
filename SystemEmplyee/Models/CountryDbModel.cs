using System.ComponentModel.DataAnnotations;

namespace SystemEmplyee.Models
{
    public class CountryDbModel
    {
        public int CountryId { get; set; }

        [Display(Name ="Country")]
        public string? CountryName { get; set; }

    }
}
