using System;
namespace TravelBlog.Models
{
    public class LocationPerson
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
