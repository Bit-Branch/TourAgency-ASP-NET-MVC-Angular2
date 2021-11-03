using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TourAgency.Common.Constant;

namespace TourAgency.Core.Models
{
    public class Hotel
    {
        public int Id { get; set; }
       
       [Required]
       [MinLength(ModelConstants.TitleMinLength)]
       [MaxLength(ModelConstants.TitleMaxLength)]
       public string Name { get; set; } 

       [Required]
       [MinLength(ModelConstants.TypeMinLength)]
       [MaxLength(ModelConstants.TypeMaxLength)]
       public string Type { get; set; } 

       [Required]
       [MinLength(ModelConstants.ContentMinLength)]
       [MaxLength(ModelConstants.ContentMaxLength)]
       public string Description { get; set; } 

       public Country Country {get;set;}

       public int CountryId { get; set; }

       public ICollection<Tour> Tours { get; set; }
    }
}