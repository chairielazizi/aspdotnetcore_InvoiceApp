using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string ServiceName { get; set; }

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int InvoiceId { get; set; }
        public required Invoice Invoice { get; set; }
    }
}
