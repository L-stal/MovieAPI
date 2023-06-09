﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieAPI.Data;

#nullable disable

namespace MovieAPI.Migrations
{
    [DbContext(typeof(MovieAPIContex))]
    partial class MovieAPIContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieAPI.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres", (string)null);

                    b.HasData(
                        new
                        {
                            GenreId = 28,
                            Description = "Big bang boom",
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = 12,
                            Description = "Mystisism and dragons",
                            Name = "Adventure"
                        },
                        new
                        {
                            GenreId = 16,
                            Description = "Computer ppl",
                            Name = "Animation"
                        },
                        new
                        {
                            GenreId = 35,
                            Description = "Laugh laugh laugh",
                            Name = "Comedy"
                        },
                        new
                        {
                            GenreId = 80,
                            Description = "Spooky cases",
                            Name = "Crime"
                        },
                        new
                        {
                            GenreId = 99,
                            Description = "Real life stuff",
                            Name = "Documentary"
                        },
                        new
                        {
                            GenreId = 18,
                            Description = "Alot of nagging",
                            Name = "Drama"
                        },
                        new
                        {
                            GenreId = 10751,
                            Description = "For everyone",
                            Name = "Family"
                        },
                        new
                        {
                            GenreId = 14,
                            Description = "Dragons,swords and sorcs",
                            Name = "Fantasy"
                        },
                        new
                        {
                            GenreId = 36,
                            Description = "Stuff before you",
                            Name = "History"
                        },
                        new
                        {
                            GenreId = 27,
                            Description = "Spooky scary skeleton",
                            Name = "Horror"
                        },
                        new
                        {
                            GenreId = 10402,
                            Description = "Dance time",
                            Name = "Music"
                        },
                        new
                        {
                            GenreId = 9648,
                            Description = "Huh? What is tihs?",
                            Name = "Mystery"
                        },
                        new
                        {
                            GenreId = 10749,
                            Description = "Love love love",
                            Name = "Romance"
                        },
                        new
                        {
                            GenreId = 878,
                            Description = "Fantasy but in space",
                            Name = "Science Fiction"
                        },
                        new
                        {
                            GenreId = 10770,
                            Description = "To bad for the big screen",
                            Name = "TV Movie"
                        },
                        new
                        {
                            GenreId = 53,
                            Description = "Nerv recking",
                            Name = "Thriller"
                        },
                        new
                        {
                            GenreId = 10752,
                            Description = "Never changes",
                            Name = "War"
                        },
                        new
                        {
                            GenreId = 37,
                            Description = "Pistol in the sand place",
                            Name = "Western"
                        });
                });

            modelBuilder.Entity("MovieAPI.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("MovieLink")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PersonId");

                    b.ToTable("Movies", (string)null);
                });

            modelBuilder.Entity("MovieAPI.Models.MovieRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("PersonId");

                    b.ToTable("MovieRatings", (string)null);
                });

            modelBuilder.Entity("MovieAPI.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("MovieAPI.Models.PersonGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonGenres", (string)null);
                });

            modelBuilder.Entity("MovieAPI.Models.Movie", b =>
                {
                    b.HasOne("MovieAPI.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MovieAPI.Models.MovieRating", b =>
                {
                    b.HasOne("MovieAPI.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MovieAPI.Models.PersonGenre", b =>
                {
                    b.HasOne("MovieAPI.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
