using System;
namespace TravelBlog.Models
{
    public class ExperiencePerson
    {
        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
