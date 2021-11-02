using System.Collections.Generic;
using TourAgency.Core.Models;

namespace TourAgency.Controllers.Resources
{
    public class PersonResource
    {
       public int Id { get; set; }

       public string Surname { get; set; } 

       public string Name { get; set; } 

       public string Patronymic { get; set; } 

       public string Email { get; set; } 

       public string Phone { get; set; } 

       public ICollection<Sale> Sales {get;set;}
    }
}