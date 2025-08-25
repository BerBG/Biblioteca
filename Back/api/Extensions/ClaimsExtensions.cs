using System.Security.Claims;

namespace api.Extensions
{
    public static class ClaimsExtensions
    {
        public static string? GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Name)
                   ?? user.FindFirstValue("unique_name")
                   ?? user.FindFirstValue("name")
                   ?? user.FindFirstValue(ClaimTypes.Email);
        }

        public static int? GetUserId(this ClaimsPrincipal user)
        {
            var raw = user.FindFirstValue(ClaimTypes.NameIdentifier)
                     ?? user.FindFirstValue("sub");
            return int.TryParse(raw, out var id)
                ? id
                : throw new FormatException("Id claim não numérica.");
        }
    }
}