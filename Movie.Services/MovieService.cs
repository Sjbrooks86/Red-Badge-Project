﻿using Movie.Data;
using Movie.Model;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services
{
    public class MovieService
    {
        private readonly Guid _userId;

        public MovieService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMovie(MovieCreate model)
        {
            var entity =
                new Flix()
                {
                    OwnerId = _userId,
                    MovieName = model.MovieName,
                    MovieDescription = model.MovieDescription,
                    MovieGenre = model.MovieGenre,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieListItem> GetMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Movies
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MovieListItem
                                {
                                    MovieId = e.MovieId,
                                    Title = e.MovieName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public MovieDetails GetMovieById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == id && e.OwnerId == _userId);
                return
                    new MovieDetails
                    {
                        MovieId = entity.MovieId,
                        Name = entity.MovieName,
                        Description = entity.MovieDescription,
                        Rating = entity.MovieRating,
                        Cast = entity.MovieCast,
                        Genre = entity.MovieGenre,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }
    }
}