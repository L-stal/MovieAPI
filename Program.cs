using MovieAPI.Data;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MovieAPIContex>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            //app.UseAuthorization();
            //Get person linked to movie(add specific) DONE
            app.MapGet("/api/Movie/{Name}", async (MovieAPIContex context , string Name) =>
            {
                var movie = context.Movies;
                var personMovies = movie.Join(context.Persons, movies => movies.PersonId,
                    per => per.PersonId, (movie, per) => new
                    {
                        movie.MovieName,
                        movie.MovieLink,
                        movie.MovieId,
                        per.FirstName

                    }).Where(x => x.FirstName == Name).ToListAsync();
                return await personMovies;
            });

            //Get Genre linked to a person DONE
            app.MapGet("/api/PersonGenre/{Name}", async (MovieAPIContex context, string Name) =>
            {
                var pGenre = from pg in context.PersonGenres
                             select new
                             {
                                 pg.Person.FirstName,
                                 pg.Genre.Name
                             };
                var getGenres = pGenre.GroupBy(x => x.FirstName)
                .Select(x => new { Name = x.Key, LikedGenres = string.Join(", ", x.Select(y => y.Name))})
                .Where(x => x.Name == Name).ToListAsync(); 
                return await getGenres;
               // return await pGenre.Where(x => x.FirstName == Name).ToListAsync();
            });
            //Get Genre DONE
            app.MapGet("/api/Genre/{name}", async (MovieAPIContex context) => await context.Genres.ToListAsync());
            //Get every person DONE
            app.MapGet("/api/Persons/", async (MovieAPIContex contex) => await contex.Persons.ToListAsync());
            //Get ratings on movies linked to person DONE
            app.MapGet("/api/Ratings/", async (MovieAPIContex context, string Name) =>
            {
                var pRating = from pr in context.MovieRatings
                              select new
                              {
                                  pr.Movie.MovieName,
                                  pr.Rating,
                                  pr.Person.FirstName
                              };
                return await pRating.Where(x => x.FirstName == Name).ToListAsync();
            });
            //Add ratings to movies linked to a person DONE
              app.MapPost("/api/Movies/{movieName}/Ratings", async (MovieAPIContex context, string movieName, int rating) =>
             {
                var movie = await context.Movies.SingleOrDefaultAsync(m => m.MovieName == movieName);
                 

                if (movie == null)
                {
                    return Results.NotFound();
                }
                var mRating = context.MovieRatings;
                if(movie.MovieId != null)
                 {
                     return Results.BadRequest();
                 }
                mRating.Add(new MovieRating { Rating = rating , MovieId = movie.MovieId, PersonId = movie.PersonId });

                await context.SaveChangesAsync();

                return Results.Created($"/api/Movies/Ratings/", rating);
            });
            //Add Person to new Genre
            app.MapPost("/api/Person/Genre/", async (MovieAPIContex context, string personName , int genreId) =>
            {
                var person = await context.Persons.SingleOrDefaultAsync(p => p.FirstName == personName);

                if (person == null)
                {
                    return Results.NotFound();
                }
                var pGenre = context.PersonGenres;
 
                pGenre.Add(new PersonGenre { PersonId = person.PersonId , GenreId = genreId});

                await context.SaveChangesAsync();

                return Results.Created($"/api/Person/Genre", genreId);
            });
            //Add movie links to specific person and genre (Return 2 to dif tabels(?))
            app.Run();  
        }

    }
}