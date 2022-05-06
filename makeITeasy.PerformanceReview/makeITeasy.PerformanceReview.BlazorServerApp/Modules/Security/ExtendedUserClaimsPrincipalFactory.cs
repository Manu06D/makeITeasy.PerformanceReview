using makeITeasy.PerformanceReview.BusinessCore.Queries.EmployeeQueries;
using makeITeasy.PerformanceReview.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using System.Security.Claims;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Modules.Security
{
    public class ExtendedUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly MediatR.IMediator _mediator;

        public ExtendedUserClaimsPrincipalFactory(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, MediatR.IMediator mediator) : base(userManager, optionsAccessor)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            var roles = await _userManager.GetRolesAsync(user);

            foreach(var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var results = await _mediator.Send(new AppFramework.Core.Queries.GenericQueryCommand<Employee>(new BasicEmployeeQuery() { UserIdentityId = user.Id }, false));

            if (results.Results.Count > 0)
            {
                identity.AddClaim(new Claim("EmployeeId", results.Results.First().Id.ToString()));
            }

            return identity;
        }
    }
}
