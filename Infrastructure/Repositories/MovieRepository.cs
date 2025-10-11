using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieWebDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Movie> GetTop30GrossingMovies()
        {
            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }
        public Movie GetMovieDetails(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Movie> GetMoviesByGenre(int id)
        {
            throw new NotImplementedException();
        }

    }
}
