using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Core.Models
{
    public class Hotel
    {
        public int Id { get; set; }
       
       [Required]
       [StringLength(255)]
       public string Name { get; set; } 

       [Required]
       [StringLength(255)]
       public string Type { get; set; } 

       [Required]
       [StringLength(255)]
       public string Description { get; set; } 

       public Country Country {get;set;}

       public int CountryId { get; set; }

       public ICollection<Tour> Tours { get; set; }
    }
}