using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TravelBlog.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set;  }
        public string Description { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }

    }
}