using Microsoft.EntityFrameworkCore;
using NCL.Shared.Entities;

namespace NCL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitorActivity> VisitorActivities { get; set; }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Moment> Moments { get; set; }
        
        public DbSet<Page> Pages { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}
