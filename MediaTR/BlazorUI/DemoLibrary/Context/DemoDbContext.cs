using DemoLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoLibrary.Context
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }

        public DbSet<PersonModel> Personas { get; set; }
    }
}