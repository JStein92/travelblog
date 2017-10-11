using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TravelBlog.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
		public virtual ICollection<Experience> Experiences { get; set; }
        //Many to many entity:
        public virtual ICollection<LocationPerson> LocationPerson { get; set; }
    }
}