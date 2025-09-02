using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public Order() => OrderItems = new List<OrderItem>();

        public int Id { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required, StringLength(50)]
        public required string Status { get; set; }

        // Foreign Key
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public required User User { get; set; }

        public required ICollection<OrderItem> OrderItems { get; set; }
    }
}
