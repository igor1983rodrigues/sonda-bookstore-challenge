using Microsoft.EntityFrameworkCore;
using SondaBookstoreApi.Model.Entity;

namespace SondaBookstoreApi.Model
{
    public class SondaBookstoreContext:DbContext
    {
        public SondaBookstoreContext(DbContextOptions<SondaBookstoreContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<BookAuthor> AuthorBooks { get; set; }
        public DbSet<BookSubject> BookSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(item => new { item.IdBook, item.IdAuthor });
            modelBuilder.Entity<BookSubject>().HasKey(item => new { item.IdBook, item.IdSubject });
            
            modelBuilder.Entity<BookAuthor>().HasOne(item => item.Book).WithMany(item => item.BookAuthors).HasForeignKey(item => item.IdBook);
            modelBuilder.Entity<BookAuthor>().HasOne(item => item.Author).WithMany(item => item.BookAuthors).HasForeignKey(item => item.IdAuthor);
            
            modelBuilder.Entity<BookSubject>().HasOne(item => item.Book).WithMany(item => item.BookSubjects).HasForeignKey(item => item.IdBook);
            modelBuilder.Entity<BookSubject>().HasOne(item => item.Subject).WithMany(item => item.BookSubjects).HasForeignKey(item => item.IdSubject);
            
        }
    }
}
