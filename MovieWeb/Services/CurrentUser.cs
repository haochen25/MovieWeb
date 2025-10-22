

using System.Security.Claims;

namespace MovieWeb.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId => Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public string Email => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;

        public string FullName => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GivenName).Value + " " +
            _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Surname).Value;

        public bool IsAdmin => throw new NotImplementedException();

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;


        public IEnumerable<string> Roles => throw new NotImplementedException();
    }
}
