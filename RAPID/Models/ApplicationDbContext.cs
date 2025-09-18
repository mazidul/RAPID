using Microsoft.EntityFrameworkCore;
using RAPID.Models;

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
    public DbSet<Language> Languages { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }    
    public DbSet<Country> Countries { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Item> Items { get; set; }
}
