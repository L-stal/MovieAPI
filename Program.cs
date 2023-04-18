using MovieAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
            //app.MapGet("/", () => "Welcome to minimal APIs");
            app.MapGet("/api/Movie/{name}", async (MovieAPIContex context)=> await context.Movies.ToListAsync());
            app.MapGet("/api/Genre/{name}", async (MovieAPIContex context) => await context.Genres.ToListAsync());



            app.Run();
        }
    }
}