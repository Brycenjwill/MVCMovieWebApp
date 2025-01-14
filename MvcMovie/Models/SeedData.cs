﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

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
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentary",
                    Rating = "G",
                    Price = 0M

                },
                new Movie
                {
                    Title = "17 Miracles",
                    ReleaseDate = DateTime.Parse("2011-06-03"),
                    Genre = "Historical Adventure",
                    Rating = "PG",
                    Price = 5.99M
                },
                new Movie
                {
                    Title = "The RM",
                    ReleaseDate = DateTime.Parse("2003-01-31"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 9.99M
                }
            );
            context.SaveChanges();
        }
    }
}
