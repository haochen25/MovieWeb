using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {   public Task<IEnumerable<Movie>> GetTop30GrossingMovies();
        public Task<PagedResultSet<Movie>> GetMoviesByGenre(int genreId, int pageIndex,int pageSize);
    }
}
