using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
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

        public IEnumerable<Movie> GetTop30RatedMovies()
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<Movie>> GetTop30GrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public async Task<PagedResultSet<Movie>> GetMoviesByGenre(int genreId, int pageIndex,int pageSize)
        {
            var movies = await _dbContext.MovieGenres
                .Where(mg => mg.GenreId == genreId)
                .Select(mg => mg.Movie)
                .OrderBy(m => m.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalCount = await _dbContext.MovieGenres
                .Where(mg => mg.GenreId == genreId)
                .Select(mg => mg.Movie)
                .CountAsync();
            var pagedResult = new PagedResultSet<Movie>(movies, totalCount, pageIndex, pageSize);
            return pagedResult;

        }
    }
}
