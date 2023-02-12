using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RpgGameAPI.Models;

namespace RpgGameAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
        }

        public DbSet<Character> Characters => Set<Character>();
        public DbSet<RoleClass> Classes => Set<RoleClass>();


    }
}
