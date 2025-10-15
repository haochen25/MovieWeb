using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        public async override Task<Movie> GetById(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.GenresOfMovie).ThenInclude(mg => mg.Genre)
                                         .Include(m => m.CastsOfMovie).ThenInclude(mc => mc.Cast)
                                         .Include(m => m.Trailers)
                                         .Include(m => m.Reviews)
                                         .FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }
        public IEnumerable<Movie> GetTop30GrossingMovies()
        {
            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }
        public IEnumerable<Movie> GetTop30RatedMovies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByGenre(int id)
        {
            throw new NotImplementedException();
        }

    }
}
