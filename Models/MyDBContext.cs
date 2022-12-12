using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace be_atributos.Models
{
    public class MyDBContext : DbContext
    {
        

        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {
           
        }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

    }
}
