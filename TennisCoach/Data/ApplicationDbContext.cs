using Microsoft.EntityFrameworkCore;
using TennisCoach.Models;

namespace TennisCoach.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSets for your entities (tables)
        public DbSet<Coaches> Coaches { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<Members> Members  { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<Admins> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coaches>()
          .HasKey(c => c.CoachId);


            // You can configure entities here if necessary
            modelBuilder.Entity<Coaches>().ToTable("Coaches");
            modelBuilder.Entity<Schedules>().ToTable("Schedules");
            modelBuilder.Entity<Members>().ToTable("Members");
            modelBuilder.Entity<Enrollments>().ToTable("Enrollments");
            modelBuilder.Entity<Admins>().ToTable("Admins");
        }
    }
}

 

