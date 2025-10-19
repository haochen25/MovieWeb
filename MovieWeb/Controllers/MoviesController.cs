using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieWeb.Controllers
{
    public class MoviesController : Controller
    {   
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _movieService.GetMovieDetail(id);
            return View(movieDetails);
        }
        public async Task<IActionResult> Genres(int id=1, int pageSize = 30, int pageIndex = 1)
        {
            var movieByGenre = await _movieService.GetMoviesByGenre(id, pageIndex, pageSize);
            return View(movieByGenre);
        }
    }
}
