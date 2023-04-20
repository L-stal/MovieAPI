using MovieAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Data
{
    public class MovieAPIContex : DbContext
    {
        public MovieAPIContex(DbContextOptions<MovieAPIContex> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PersonGenre> PersonGenres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Genre>().HasData(new Genre[] {
        //        new Genre{GenreId=28,Name="Action", Description="Big bang boom"},
        //        new Genre{GenreId=12,Name="Adventure", Description="Mystisism and dragons"},
        //        new Genre{GenreId=16,Name="Animation", Description="Computer ppl"},
        //        new Genre{GenreId=35,Name="Comedy", Description="Laugh laugh laugh"},
        //        new Genre{GenreId=80,Name="Crime", Description="Spooky cases"},
        //        new Genre{GenreId=99,Name="Documentary", Description="Real life stuff"},
        //        new Genre{GenreId=18,Name="Drama", Description="Alot of nagging"},
        //        new Genre{GenreId=10751,Name="Family", Description="For everyone"},
        //        new Genre{GenreId=14,Name="Fantasy", Description="Dragons,swords and sorcs"},
        //        new Genre{GenreId=36,Name="History", Description="Stuff before you"},
        //        new Genre{GenreId=27,Name="Horror", Description="Spooky scary skeleton"},
        //        new Genre{GenreId=10402,Name="Music", Description="Dance time"},
        //        new Genre{GenreId=9648,Name="Mystery", Description="Huh? What is tihs?"},
        //        new Genre{GenreId=10749,Name="Romance", Description="Love love love"},
        //        new Genre{GenreId=878,Name="Science Fiction", Description="Fantasy but in space"},
        //        new Genre{GenreId=10770,Name="TV Movie", Description="To bad for the big screen"},
        //        new Genre{GenreId=53,Name="Thriller", Description="Nerv recking"},
        //        new Genre{GenreId=10752,Name="War", Description="Never changes"},
        //        new Genre{GenreId=37,Name="Western", Description="Pistol in the sand place"}
        //    });

            //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-NLV7J33; Initial Catalog=MovieAPI;Integrated Security=true");

            //}
        
    }
}
