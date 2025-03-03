using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FinancialManager.Data;
using FinancialManager.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Retrieve connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// ✅ Register FinancialManagerContext (DbContext for EF Core)
builder.Services.AddDbContext<FinancialManagerContext>(options =>
    options.UseSqlServer(connectionString));

// ✅ Configure Identity (Allow users to log in without email confirmation)
builder.Services.AddDefaultIdentity<FinancialManagerUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // 🔥 Disable email confirmation
})
    .AddEntityFrameworkStores<FinancialManagerContext>();

// ✅ Add MVC and Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ✅ Middleware pipeline setup
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// ✅ Set Default Route to Expenses
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Expenses}/{action=Index}/{id?}"); // 🔥 Now defaults to /Expenses

// ✅ Ensure Identity Razor Pages work (e.g., Login/Register)
app.MapRazorPages();

// ✅ Start the application
app.Run();
