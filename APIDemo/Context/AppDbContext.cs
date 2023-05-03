using APIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Personasdb> Personasdb { get; set; }

    }
}
