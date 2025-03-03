public class Debt
{
    public int Id { get; set; }

    public string Creditor { get; set; } = string.Empty; // Ensures it's never null

    public decimal Amount { get; set; }

    public DateTime DueDate { get; set; }

    // Constructor to initialize Creditor
    public Debt()
    {
        Creditor = string.Empty;
    }
}