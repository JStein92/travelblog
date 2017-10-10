using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models

{
    public class PersonExperiences
    {
        [Key]
        public int ExperienceId { get; set; }

        [Key]
        public int PersonId { get; set; }
    }
}
