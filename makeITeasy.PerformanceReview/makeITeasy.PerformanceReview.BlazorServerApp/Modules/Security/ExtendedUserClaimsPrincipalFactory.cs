using makeITeasy.AppFramework.Core.Queries;
using makeITeasy.PerformanceReview.BusinessCore.Queries.EmployeeQueries;
using makeITeasy.PerformanceReview.Models;

using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using System.Data;
using System.Security.Claims;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Modules.Security
{
    public class ExtendedUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMediator _mediator;

        public ExtendedUserClaimsPrincipalFactory(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor, IMediator mediator) : base(userManager, optionsAccessor)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            ClaimsIdentity identityClaim = await base.GenerateClaimsAsync(user);
            IList<string> roles = await _userManager.GetRolesAsync(user);

            AddRolesToIdentityClaims(identityClaim, roles);

            //await AddCustomClaimsAsync(user, identityClaim);

            return identityClaim;
        }

        private async Task AddCustomClaimsAsync(AppUser user, ClaimsIdentity identity)
        {
            QueryResult<Employee> results =
                await _mediator.Send(new GenericQueryCommand<Employee>(new BasicEmployeeQuery() { UserIdentityId = user.Id }, false));

            if (results?.Results?.Count > 0)
            {
                identity.AddClaim(new Claim("EmployeeId", results.Results.First().Id.ToString()));
            }
        }

        private static void AddRolesToIdentityClaims(ClaimsIdentity identity, IList<string> roles)
{
            identity.AddClaims(roles.Distinct().Select(x => new Claim(ClaimTypes.Role, x)));
        }
    }
}
