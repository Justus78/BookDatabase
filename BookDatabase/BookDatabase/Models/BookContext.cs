using Microsoft.EntityFrameworkCore;

namespace BookDatabase.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<BookAuthor> BookAuthors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany(a => a.Authors).WithMany(b => b.Books).UsingEntity<BookAuthor>();

            

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId =  1 , AuthorName = "Opal Reyne"},
                new Author { AuthorId = 2, AuthorName = "Sarah J. Maas" },
                new Author { AuthorId = 3, AuthorName = "H.D. Carlton" }
                );           

            modelBuilder.Entity<Genre>().HasData(
                new Genre {
                    GenreId = 1,
                    Name = "Young Adult"
                }, new Genre { 
                    GenreId = 2,
                    Name = "Fantasy"
                }, new Genre {
                    GenreId = 3,
                    Name = "Fantasy Romance"
                }, new Genre { 
                    GenreId = 4,
                    Name = "Romance"
                },  new Genre {
                    GenreId = 5,
                    Name = "Erotic"
                }, new Genre { 
                    GenreId = 6,
                    Name = "Thriller"
                },  new Genre {
                    GenreId = 7,
                    Name = "Drama"
                }, new Genre { 
                    GenreId = 8,
                    Name = "Taboo"
                }, new Genre { 
                    GenreId = 9,
                    Name = "Monster Romance"
                }, new Genre { 
                    GenreId = 10,
                    Name = "Dark Romance"
                }, new Genre { 
                    GenreId = 11,
                    Name = "Reverse Harem"
                });

            modelBuilder.Entity<Status>().HasData(
                new Status { 
                    StatusId = 1,
                    StatusName = "To Be Read"
                }, new Status { 
                    StatusId = 2,
                    StatusName = "Read"
                }, new Status { 
                    StatusId = 3,
                    StatusName = "Wishlist"
                });

            modelBuilder.Entity<Book>().HasData(
                new Book { 
                    BookId = 1,
                    Title = "A Soul to Keep", 
                    GenreId = 9,
                    StatusId = 2
                }, new Book { 
                    BookId = 2,
                    Title = "A Court of Thorns and Roses",
                    GenreId = 3,
                    StatusId = 2
                }, new Book { 
                    BookId = 3,
                    Title = "Satan's Affair",
                    GenreId = 10,
                    StatusId = 1
                });

             modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { BookId = 1, AuthorId = 1},
                new BookAuthor { BookId = 2, AuthorId = 2 },
                new BookAuthor { BookId = 3, AuthorId = 3 }
                );
        } // end Model Builder

    } // end Context class
} // end namespace
