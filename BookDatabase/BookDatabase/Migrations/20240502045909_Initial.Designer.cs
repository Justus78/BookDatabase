﻿// <auto-generated />
using BookDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookDatabase.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20240502045909_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookDatabase.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            AuthorName = "Opal Reyne"
                        },
                        new
                        {
                            AuthorId = 2,
                            AuthorName = "Sarah J. Maas"
                        },
                        new
                        {
                            AuthorId = 3,
                            AuthorName = "H.D. Carlton"
                        });
                });

            modelBuilder.Entity("BookDatabase.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("GenreId");

                    b.HasIndex("StatusId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            GenreId = 9,
                            StatusId = 2,
                            Title = "A Soul to Keep"
                        },
                        new
                        {
                            BookId = 2,
                            GenreId = 3,
                            StatusId = 2,
                            Title = "A Court of Thorns and Roses"
                        },
                        new
                        {
                            BookId = 3,
                            GenreId = 10,
                            StatusId = 1,
                            Title = "Satan's Affair"
                        });
                });

            modelBuilder.Entity("BookDatabase.Models.BookAuthor", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            BookId = 1
                        },
                        new
                        {
                            AuthorId = 2,
                            BookId = 2
                        },
                        new
                        {
                            AuthorId = 3,
                            BookId = 3
                        });
                });

            modelBuilder.Entity("BookDatabase.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Name = "Young Adult"
                        },
                        new
                        {
                            GenreId = 2,
                            Name = "Fantasy"
                        },
                        new
                        {
                            GenreId = 3,
                            Name = "Fantasy Romance"
                        },
                        new
                        {
                            GenreId = 4,
                            Name = "Romance"
                        },
                        new
                        {
                            GenreId = 5,
                            Name = "Erotic"
                        },
                        new
                        {
                            GenreId = 6,
                            Name = "Thriller"
                        },
                        new
                        {
                            GenreId = 7,
                            Name = "Drama"
                        },
                        new
                        {
                            GenreId = 8,
                            Name = "Taboo"
                        },
                        new
                        {
                            GenreId = 9,
                            Name = "Monster Romance"
                        },
                        new
                        {
                            GenreId = 10,
                            Name = "Dark Romance"
                        },
                        new
                        {
                            GenreId = 11,
                            Name = "Reverse Harem"
                        });
                });

            modelBuilder.Entity("BookDatabase.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            StatusName = "To Be Read"
                        },
                        new
                        {
                            StatusId = 2,
                            StatusName = "Read"
                        },
                        new
                        {
                            StatusId = 3,
                            StatusName = "Wishlist"
                        });
                });

            modelBuilder.Entity("BookDatabase.Models.Book", b =>
                {
                    b.HasOne("BookDatabase.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookDatabase.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("BookDatabase.Models.BookAuthor", b =>
                {
                    b.HasOne("BookDatabase.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookDatabase.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
