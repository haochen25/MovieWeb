using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTop30GrossingMovies();
            return Ok(movies);
        }
        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovieDetail(int id)
        {
            var movie = await _movieService.GetMovieDetail(id);
            return Ok(movie);
        }
    }
}
