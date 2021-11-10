using System;

namespace TourAgency.Controllers.Resources
{
    public class SaleResource
    {
       public int Id { get; set; }
       
       public DateTime SaleTime { get; set; } 

       public int Count { get; set; } 

       public PersonResource Person {get;set;}

       public TourResource Tour {get;set;}
    }
}