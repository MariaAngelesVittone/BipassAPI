using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Venue
    {
        public Venue() => Events = new List<Event>();

        public int Id { get; set; }

        [Required, StringLength(200)]
        public required string Name { get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        public int Capacity { get; set; }

        public required ICollection<Event> Events { get; set; }
    }
}
