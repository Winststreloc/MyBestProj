using HomeWork09._12.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork09._12.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBook>()
                .HasKey(ub => new { ub.BookId, ub.UserId });
            modelBuilder.Entity<UserBook>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBooks)
                .HasForeignKey(ub => ub.BookId);
            modelBuilder.Entity<UserBook>()
                .HasOne(ub => ub.Book)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(ub => ub.UserId);

            modelBuilder.Entity<Author>()
                .HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>()
                .HasMany<Book>(a => a.Books)
                .WithOne(b => b.Author)
                .IsRequired();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=HomeWorkEf;Trusted_Connection=True;");
        }
    }
}