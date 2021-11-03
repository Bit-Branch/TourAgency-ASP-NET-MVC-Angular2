using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TourAgency.Common.Constant;

namespace TourAgency.Core.Models
{
    public class Person
    {
        public int Id { get; set; }
       
       [Required]
       [MinLength(ModelConstants.TitleMinLength)]
       [MaxLength(ModelConstants.TitleMaxLength)]
       public string Surname { get; set; } 

       [Required]
       [MinLength(ModelConstants.TitleMinLength)]
       [MaxLength(ModelConstants.TitleMaxLength)]
       public string Name { get; set; } 

       [Required]
       [MinLength(ModelConstants.TitleMinLength)]
       [MaxLength(ModelConstants.TitleMaxLength)]
       public string Patronymic { get; set; } 

        //TODO validation
       [Required]
       [MinLength(ModelConstants.TitleMinLength)]
       [MaxLength(ModelConstants.TitleMaxLength)]
       public string Email { get; set; } 

        //TODO validation
       [Required]
       [MinLength(ModelConstants.TitleMinLength)]
       [MaxLength(ModelConstants.TitleMaxLength)]
       public string Phone { get; set; } 

       public ICollection<Sale> Sales {get;set;}
    }
}