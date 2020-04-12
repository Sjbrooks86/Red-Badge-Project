using Movie.Data;
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
                    MovieName = model.Name,
                    MovieDescription = model.Description,
                    MovieRating = model.Rating,
                    MovieCast = model.Cast,
                    MovieGenre = model.Genre,
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

        public bool UpdateMovie(MovieEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == model.MovieId && e.OwnerId == _userId);

                entity.MovieId = model.MovieId;
                entity.MovieName = model.Name;
                entity.MovieDescription = model.Description;
                entity.MovieRating = model.Rating;
                entity.MovieCast = model.Cast;
                entity.MovieGenre = model.Genre;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMovie(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == movieId && e.OwnerId == _userId);

                ctx.Movies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}