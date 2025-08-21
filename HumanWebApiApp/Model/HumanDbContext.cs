using Microsoft.EntityFrameworkCore;

namespace HumanWebApiApp.Model
{
    public class HumanDbContext : DbContext
    {
        public DbSet<Human> humans { get; set; }
        public HumanDbContext(DbContextOptions options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Human>().HasKey(x => x.id);
        }
    }
}
