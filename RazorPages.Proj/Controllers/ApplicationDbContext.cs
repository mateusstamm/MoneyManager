using Microsoft.EntityFrameworkCore;

namespace RazorPages.Proj.Models;

public class ApplicationDbContext : DbContext 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer("Server=database;Database=moneymanager_db;User Id=sa;Password='MoneyManager@*@2023';TrustServerCertificate=true;", options =>
    {
        options.EnableRetryOnFailure(3);
    });
}


    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }

}