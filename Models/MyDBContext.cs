using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace be_atributos.Models
{
    public class MyDBContext : IdentityDbContext    
    {
        public MyDBContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

    }
}
