using MovieAPI.Data;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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
            //Get person linked to movie DONE
            app.MapGet("/api/Person/GetMovies/", async (MovieAPIContex context , string Name) =>
            {
                //Joins the name of the person to the ratings.
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
            app.MapGet("/api/PersonGenre/", async (MovieAPIContex context, string Name) =>
            {
                var pGenre = from pg in context.PersonGenres
                             select new
                             {
                                 pg.Person.FirstName,
                                 pg.Genre.Name
                             };
                //Adds all genres to one row and prints them out one after another , instead of a new body for each genre
                var getGenres = pGenre.GroupBy(x => x.FirstName)
                .Select(x => new { Name = x.Key, LikedGenres = string.Join(", ", x.Select(y => y.Name))})
                .Where(x => x.Name == Name).ToListAsync(); 
                return await getGenres;
            // return await pGenre.Where(x => x.FirstName == Name).ToListAsync();
            });
            //Get Genre DONE
            app.MapGet("/api/Genre/GetAllGenre/", async (MovieAPIContex context) => await context.Genres.ToListAsync());
            //Get every person DONE
            app.MapGet("/api/Persons/GetPersons/", async (MovieAPIContex contex) => await contex.Persons.ToListAsync());
            //Get ratings on movies linked to person DONE
            app.MapGet("/api/Person/GetRating/", async (MovieAPIContex context, string Name) =>
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
            app.MapPost("/api/Movies/AddRatings/", async (MovieAPIContex context, string movieName, int rating) =>
            {
                var movie = await context.Movies.FirstOrDefaultAsync(m => m.MovieName == movieName);
                 

                if (movie == null)
                {
                    return Results.NotFound();
                }
                var mRating = context.MovieRatings;
                mRating.Add(new MovieRating { Rating = rating , MovieId = movie.MovieId, PersonId = movie.PersonId });

                await context.SaveChangesAsync();

                return Results.Created($"/api/Movies/AddRatings/", rating);
            });
            //Add Person to new Genre DONE
            app.MapPost("/api/Person/AddGenre/", async (MovieAPIContex context, string personName , int genreId) =>
            {
                var person = await context.Persons.SingleOrDefaultAsync(p => p.FirstName == personName);

                if (person == null)
                {
                    return Results.NotFound();
                }
                var pGenre = context.PersonGenres;
 
                pGenre.Add(new PersonGenre { PersonId = person.PersonId , GenreId = genreId});

                await context.SaveChangesAsync();

                return Results.Created($"/api/Person/AddGenre", genreId);
            });
            //Add movie links to specific person and genre)
            app.MapPost("/api/Person/AddMovieLink/", async (MovieAPIContex context, string personName, string movieName , string genreName, string movieLink) =>
            {
                var person = await context.Persons.SingleOrDefaultAsync(p => p.FirstName == personName);
                if (person == null)
                {
                    return Results.NotFound();
                }

                var movie = await context.Movies.FirstOrDefaultAsync(m => m.MovieName == movieName);
                if (movie != null)
                {
                    return Results.BadRequest();
                }

                var genre = await context.Genres.FirstOrDefaultAsync(g => g.Name == genreName);
                if (genre.Name != genreName)
                {
                    return Results.BadRequest();
                }
                var mLink = await context.Movies.FirstOrDefaultAsync(ml => ml.MovieLink == movieLink);
                var movieAdd = context.Movies;
                movieAdd.Add(new Movie { PersonId = person.PersonId, MovieName = movieName , GenreId = genre.GenreId , MovieLink = movieLink });


                await context.SaveChangesAsync();

                return Results.Created($"/api/Person/AddMovieLink/", movieAdd);
            });
            app.MapGet("/api/Recommendations/", async (MovieAPIContex context, string GenreName) =>
            {
                var genre = await context.Genres.FirstOrDefaultAsync(g => g.Name == GenreName);
                //Add your own api key from The Movie DataBase below
                var apiKey = "";
                var url = $"https://api.themoviedb.org/3/discover/movie?api_key={apiKey}&sort_by=popularity.desc&include_adult=true&include_video=false&with_genres={genre.GenreId}&with_watch_monetization_types=free";

                var client = new HttpClient();

                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                //This returns the raw dataas json , easier to read
                return Results.Content(content, contentType: "application/json");
            });
            app.MapGet("/api/Person/FilterByLetter/", async (MovieAPIContex context, string letters) =>
            {
                var pRating = from pr in context.Persons
                              select new
                              {
                                 pr.FirstName
                              };
                return await pRating.Where(x => x.FirstName.Contains(letters)).ToListAsync();
            });
            app.MapGet("/api/Person/GetMoviesGenre/", async (MovieAPIContex context, string Name) =>
            {
                //Joins the name of the person to the ratings.
                var movie = context.Movies;
                var personMovies = movie.Join(context.Persons, movies => movies.PersonId,
                    per => per.PersonId, (movie, per) => new
                    {
                        movie.MovieName,
                        movie.MovieLink,
                        movie.Genre.Name,
                        per.FirstName

                    }).Where(x => x.FirstName == Name).ToListAsync();
                return await personMovies;
            });
            app.Run();  
        }

    }
}