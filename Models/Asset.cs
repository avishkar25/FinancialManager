namespace FinancialManager.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public required string Name { get; set; } // ✅ Fixes the warning
        public decimal Value { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
