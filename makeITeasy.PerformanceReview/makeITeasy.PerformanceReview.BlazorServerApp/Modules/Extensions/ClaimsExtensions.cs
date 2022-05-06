using System.Security.Claims;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Modules.Extensions
{
    public static class ClaimsExtensions
    {
        public static string? GetIdentityUserID(this ClaimsPrincipal claimPrincipal)
        {
            return claimPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        public static List<string> GetRoles(this ClaimsPrincipal claimPrincipal)
        {
            return claimPrincipal.Claims.Where(x => x.Type == System.Security.Claims.ClaimTypes.Role).Select(x => x.Value).ToList();
        }
    }
}
