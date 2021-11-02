using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourAgency.Core.Models
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }
       
       [Required]
       [StringLength(255)]
       public string Name { get; set; } 

       public ICollection<Hotel> Hotels { get; set; }

       
    }
}