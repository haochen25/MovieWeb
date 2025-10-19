using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    { 
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository MovieRepository)
        {
            _movieRepository = MovieRepository;
        }
        public async Task<List<MovieCard>> GetTop30GrossingMovies()
        {
            var movies = await _movieRepository.GetTop30GrossingMovies();
            var result = new List<MovieCard>();
            foreach(var movie in movies)
            {
                result.Add(new MovieCard { Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl });
            }
            return result;
        }
        public async Task<MovieDetailModel> GetMovieDetail(int id)
        {
            var movie = await _movieRepository.GetById(id);
            if (movie == null) return null;
            var movieDetail = new MovieDetailModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Tagline = movie.Tagline,
                Overview = movie.Overview,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Rating = movie.Reviews.Any() ? (decimal)movie.Reviews.Average(r => r.Rating) : 0
            };
            movieDetail.Casts = new List<CastModel>();
            foreach(var cast in movie.CastsOfMovie)
            {
                movieDetail.Casts.Add(new CastModel
                {
                    Id = cast.Cast.Id,
                    Name = cast.Cast.Name,
                    Character = cast.Character,
                    ProfilePath = cast.Cast.ProfilePath
                });
            }
            movieDetail.Trailers = new List<TrailerModel>();
            foreach(var trailer in movie.Trailers)
            {
                movieDetail.Trailers.Add(new TrailerModel { Id = trailer.Id, Name = trailer.Name, TrailerUrl = trailer.TrailerUrl });
            }
            movieDetail.Genres = new List<GenreModel>();
            foreach (var genre in movie.GenresOfMovie)
            {
                movieDetail.Genres.Add(new GenreModel { Id = genre.GenreId, Name = genre.Genre.Name});
            }
            return movieDetail;
        }
        public async Task<PagedResultSet<MovieCard>> GetMoviesByGenre(int id, int pageIndex = 1, int pageSize = 30)
        {
            var movies = await _movieRepository.GetMoviesByGenre(id,pageIndex,pageSize);
            var result = new List<MovieCard>();
            foreach (var movie in movies.Data)
            {
                result.Add(new MovieCard { Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl });
            }
            return new PagedResultSet<MovieCard>(result, movies.TotalCount, pageIndex, pageSize);
        }

    }
}
