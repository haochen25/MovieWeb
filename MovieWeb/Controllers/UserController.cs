using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieWeb.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {   var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            return View();
        }
    }
}
