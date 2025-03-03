using Microsoft.AspNetCore.Identity;

namespace FinancialManager.Models
{
    public class FinancialManagerUser : IdentityUser
    {
        // You can add custom fields here, e.g.:
        public string FullName { get; set; } = string.Empty; // Prevents null warning
    }
}
