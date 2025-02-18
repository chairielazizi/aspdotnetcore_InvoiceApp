using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Models;

public class Invoice
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Number { get; set; }
    
    [Required]
    public string Status { get; set; }
    public DateOnly? IssueData { get; set; }
    public DateOnly? DueDate { get; set; }

    //service details
    public string ServiceName { get; set; }
    
    [Precision(18, 2)]
    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    //client details
    public string ClientName { get; set; }
    public string ClientAddress { get; set; }
    public string ClientEmail { get; set; }
    public string ClientPhoneNumber { get; set; }
}
