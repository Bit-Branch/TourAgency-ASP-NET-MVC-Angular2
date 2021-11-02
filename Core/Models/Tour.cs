using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourAgency.Core.Models
{
    public class Tour
    {
       public int Id { get; set; }

       [Required]
       [StringLength(255)]
       public string Name { get; set; } 

       [Required]
       [Column(TypeName = "decimal(18,4)")]
       public decimal Price { get; set; } 

       [Required]
       public DateTime DepartureTime { get; set; } 

       [Required]
       [StringLength(255)]
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