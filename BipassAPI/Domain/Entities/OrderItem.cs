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
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        // Foreign Key
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public required Order Order { get; set; }

        // Foreign Key
        public int TicketTypeId { get; set; }
        [ForeignKey("TicketTypeId")]
        public required Ticket Ticket { get; set; }
    }
}
