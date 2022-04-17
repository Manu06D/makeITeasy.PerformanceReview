using Microsoft.AspNetCore.Components.Authorization;

using System.Security.Claims;

namespace makeITeasy.PerformanceReview.BlazorApp.Modules.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(1500);

            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "testUser"), }, "TestUser authentication type");
            var user = new ClaimsPrincipal(identity);
            //return await Task.FromResult(new AuthenticationState(user));

            var anonymous = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }
    }
}
