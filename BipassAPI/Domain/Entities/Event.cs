using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class Event
    {
        public Event() => Tickets = new List<Ticket>();

        public int Id { get; set; }

        [Required, StringLength(200)]
        public required string Name { get; set; }

        public required string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsStreaming { get; set; }
        public string? StreamingUrl { get; set; }

        // Foreign Key
        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        public required Venue Venue { get; set; }

        public required ICollection<Ticket> Tickets { get; set; }
    }
}
