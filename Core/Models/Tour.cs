using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TourAgency.Common.Constant;

namespace TourAgency.Core.Models
{
    public class Tour
    {
       public int Id { get; set; }

       [Required]
       [MinLength(ModelConstants.TitleMinLength)]
       [MaxLength(ModelConstants.TitleMaxLength)]
       public string Name { get; set; } 

       [Required]
       [Column(TypeName = "decimal(18,4)")]
       [Range(0, ModelConstants.PriceMaxValue)]
       public decimal Price { get; set; } 

       [Required]
       public DateTime DepartureTime { get; set; } 

       [Required]
       [MinLength(ModelConstants.TitleMinLength)]
       [MaxLength(ModelConstants.TitleMaxLength)]
       public String DepartureCity { get; set; } 

       [Required]
       public int DaysCount { get; set; }

       [Required]
       public int NightsCount { get; set; }

       public Hotel Hotel {get;set;}

       public int HotelId {get;set;}

       public ICollection<Sale> Sales { get; set; }
    }
}