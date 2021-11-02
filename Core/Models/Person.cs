using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Core.Models
{
    public class Person
    {
        public int Id { get; set; }
       
       [Required]
       [StringLength(255)]
       public string Surname { get; set; } 

       [Required]
       [StringLength(255)]
       public string Name { get; set; } 

       [Required]
       [StringLength(255)]
       public string Patronymic { get; set; } 

        //TODO validation
       [StringLength(255)]
       public string Email { get; set; } 

        //TODO validation
       [Required]
       [StringLength(255)]
       public string Phone { get; set; } 

       public ICollection<Sale> Sales {get;set;}
    }
}