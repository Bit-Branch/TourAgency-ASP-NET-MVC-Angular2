using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TourAgency.Common.Constant;

namespace TourAgency.Core.Models
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }
       
       [Required]
       [MinLength(ModelConstants.TitleMinLength)]
       [MaxLength(ModelConstants.TitleMaxLength)]
       public string Name { get; set; } 

       public ICollection<Hotel> Hotels { get; set; }

       
    }
}