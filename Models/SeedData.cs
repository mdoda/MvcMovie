using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        GenreId = 3,
                        Rating = "R",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/WhenHarryMetSallyPoster.jpg",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        GenreId = 1,
                        Rating = "R",
                        ImageUrl = "https://exaircorp.files.wordpress.com/2014/02/ghostbusters.jpg",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        GenreId = 1,
                        Rating = "R",
                        ImageUrl = "https://image.tmdb.org/t/p/original/cbXZ85KLpLux7GfGHuESZYbmEX6.jpg",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        GenreId = 4,
                        Rating = "R",
                        ImageUrl = "https://myfavoritewesterns.files.wordpress.com/2017/02/rio-bravo-poster.jpg",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
