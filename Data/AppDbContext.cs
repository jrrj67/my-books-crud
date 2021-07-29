using Microsoft.EntityFrameworkCore;
using my_books.Models;

namespace my_books.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(b => b.BookId);
            
            modelBuilder.Entity<Book_Author>()
                .HasOne(a => a.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(a => a.AuthorId);
        }

        public DbSet<Book> Books { get; set; }
        
        public DbSet<Publisher> Publishers { get; set; }
 
        public DbSet<Author> Authors { get; set; }
        
        public DbSet<Book_Author> Books_Authors { get; set; }
    }
}
