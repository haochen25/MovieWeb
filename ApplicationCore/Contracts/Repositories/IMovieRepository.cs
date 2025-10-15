using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {   public IEnumerable<Movie> GetTop30GrossingMovies();
        public IEnumerable<Movie> GetMoviesByGenre(int id);
    }
}
