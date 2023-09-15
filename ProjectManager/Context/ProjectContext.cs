using Microsoft.EntityFrameworkCore;
using ProjectManager.Models;

namespace ProjectManager.Context
{
    public class ProjectContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ProjectContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("Connection"));
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Issue>()
                .Property(d => d.Created)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .Property(u => u.UserCreated)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Project>()
                .Property(p => p.Created)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Issue>()
                .Property(i => i.Updated)
                .ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Project>()
                .Property(p => p.Updated)
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Reporter)
                .WithMany(u => u.ReportedIssues)
                .HasForeignKey(i => i.ReporterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
