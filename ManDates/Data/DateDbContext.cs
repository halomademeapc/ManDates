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
    }
}
