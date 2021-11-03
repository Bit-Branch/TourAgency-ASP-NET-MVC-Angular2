using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Core.Models
{
    public class Sale
    {
       public int Id { get; set; }
       
       [Required]
       public DateTime SaleTime { get; set; } 

       [Required]
       public int Count { get; set; } 

       public Person Person {get;set;}

       public int PersonId { get; set; }

       public Tour Tour {get;set;}

       public int TourId { get; set; }
    }
}