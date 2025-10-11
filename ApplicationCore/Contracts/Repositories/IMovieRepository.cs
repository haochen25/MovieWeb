using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository
    {   public IEnumerable<Movie> GetTop30GrossingMovies();
        public Movie GetMovieDetails(int id);
        public IEnumerable<Movie> GetMoviesByGenre(int id);
    }
}
