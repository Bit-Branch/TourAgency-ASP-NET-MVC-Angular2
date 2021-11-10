using System;

namespace TourAgency.Controllers.Resources
{
    public class SaveTourResource
    {
       public int Id { get; set; }

       public string Name { get; set; } 

       public decimal Price { get; set; } 

       public DateTime DepartureTime { get; set; } 

       public String DepartureCity { get; set; } 

       public int DaysCount { get; set; }

       public int NightsCount { get; set; }

       public int HotelId {get;set;}
    }
}