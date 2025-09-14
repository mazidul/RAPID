using Microsoft.EntityFrameworkCore;

namespace RAPID.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    //>>>>>>>>>>>>>Start of customer<<<<<<<<<<<<<<
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<PaymentMode> PaymentModes { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Language> Languagees { get; set; }
    public DbSet<State> State { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    //>>>>>>>>>>>>>End of customer <<<<<<<<<<<<<<
}
