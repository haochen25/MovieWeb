using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        public Task<List<MovieCard>> GetTop30GrossingMovies();
        public Task<MovieDetailModel> GetMovieDetail(int id);
        public Task<PagedResultSet<MovieCard>> GetMoviesByGenre(int id, int pageSize = 30, int pageNumber = 1);

    }
}
