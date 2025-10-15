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
        public List<MovieCard> GetTop30GrossingMovies();
        public Task<MovieDetailModel> GetMovieDetail(int id);

    }
}
