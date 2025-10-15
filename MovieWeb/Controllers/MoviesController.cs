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

        public async Task<IActionResult> Detail(int id)
        {
            var movieDetails = await _movieService.GetMovieDetail(id);
            return View(movieDetails);
        }
    }
}
