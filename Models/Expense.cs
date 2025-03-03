using System;
using System.ComponentModel.DataAnnotations;

public class Expense
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }

    public string? Category { get; set; }

    [Required]
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
