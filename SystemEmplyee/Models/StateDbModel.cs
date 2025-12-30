using System.ComponentModel.DataAnnotations;

namespace SystemEmplyee.Models
{
    public class StateDbModel
    {

        public int StateId { get; set; }

        [Display(Name ="State Name")]
        public string StateName { get; set; }

        public int CountId { get; set; }


    }
}
