using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Security;

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
            return claimPrincipal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();
        }

        public static bool IsEmployee(this ClaimsPrincipal claimPrincipal)
        {
            return claimPrincipal.Claims.Any(x => x.Type == ClaimTypes.Role && x.Value == Role.Employee.ToString().ToLower());
        }
    }
}
