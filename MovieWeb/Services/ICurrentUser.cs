namespace MovieWeb.Services
{
    public interface ICurrentUser
    {
        int UserId { get; }
        string Email { get; }
        string FullName { get; }
        bool IsAdmin { get; }
        bool IsAuthenticated { get; }

        IEnumerable<string> Roles { get; }
    }
}
