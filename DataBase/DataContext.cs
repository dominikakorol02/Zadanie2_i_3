using Microsoft.EntityFrameworkCore;
using Zadanie3_przetwarzanie_rozproszone.Models;

namespace Zadanie3_przetwarzanie_rozproszone
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasIndex(p => p.Id).IsUnique();
        }
        public DbSet<Person> Persons => Set<Person>();
    }
}
