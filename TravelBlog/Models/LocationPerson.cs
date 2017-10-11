using System;
namespace TravelBlog.Models
{
    public class LocationPerson
    {
        public int LocationId { get; set; }
        public int PersonId { get; set; }

        //Relationships
        public Location Location { get; set; }
        public Person Person { get; set; }
    }
}
