using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
  
    public class YourDbContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-D8S3V2D;Database=testDB;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .Property(b => b.Cost)
                .HasColumnType("decimal(18,2)");
        }

    }

}
