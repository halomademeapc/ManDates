using ManDates.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManDates.Data
{
    public class DateDbContext : DbContext
    {
        public DateDbContext(DbContextOptions<DateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .Property(g => g.DurationInWeeks)
                .HasDefaultValue(1);
        }
    }
}
