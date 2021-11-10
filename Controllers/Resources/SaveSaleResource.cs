using System;

namespace TourAgency.Controllers.Resources
{
    public class SaveSaleResource
    {
       public int Id { get; set; }
       public DateTime SaleTime { get; set; } 
       public int Count { get; set; } 
       public int PersonId { get; set; }
       public int TourId { get; set; }
    }
}