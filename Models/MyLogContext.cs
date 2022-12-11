using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace be_atributos.Models
{
    public class MyLogContext: DbContext
    {
        public MyLogContext( DbContextOptions<MyLogContext> myLogContext)
            :base(myLogContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppLog>()
                .Property(p => p.Title)
                .IsRequired();
            modelBuilder.Entity<AppLog>()
                .Property(p => p.Message)
                .IsRequired()
                .HasMaxLength(100);
        }

        public DbSet<AppLog> appLogs;  
    }
}
