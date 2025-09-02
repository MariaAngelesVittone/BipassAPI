using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public required string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int QuantityAvailable { get; set; }

        // Foreign Key
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public required Event Event { get; set; }
    }
}
