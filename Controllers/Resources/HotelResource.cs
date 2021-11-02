using System.Collections.Generic;
using TourAgency.Core.Models;

namespace TourAgency.Controllers.Resources
{
    public class HotelResource
    {
         public int Id { get; set; }
       public string Name { get; set; } 
       public string Type { get; set; } 
       public string Description { get; set; } 
       public ICollection<Tour> Tours { get; set; }
    }
}