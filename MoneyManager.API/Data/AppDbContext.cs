using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace MoneyManager.API.Data{
    public class AppDbContext : DbContext
    {
        public DbSet<CategoriaModel>? Categorias {get; set;}
        public DbSet<TransacaoModel>? Transacoes {get; set;}

        static readonly string connectionString = "Server=db_mysql;Port=3306;Database=moneymanager_db;Uid=root;Pwd=moneymanager;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql(connectionString,
                                    ServerVersion.AutoDetect(connectionString));
        }

            
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CategoriaModel>().ToTable("Categoria");
            modelBuilder.Entity<TransacaoModel>().ToTable("Transacao");
        }
    }
}