using HomeWorkMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkMVC.Data
{
    public class SupportDbContext : DbContext
    {
        public SupportDbContext(DbContextOptions<SupportDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<SupportSpecialist> SupportSpecialists { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupportSpecialist>()
                .HasKey(ss => ss.Id);
            modelBuilder.Entity<SupportSpecialist>()
                .HasOne( x => x.Department)
                .WithMany(x => x.SupportSpecialists)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<SupportRequest>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<SupportRequest>()
                .HasOne(x => x.SupportSpecialist)
                .WithMany(x => x.SupportRequests)
                .HasForeignKey(x => x.SupportSpecialistId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SupportRequest>()
                .HasOne(x => x.Department)
                .WithMany(x => x.SupportRequests)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}