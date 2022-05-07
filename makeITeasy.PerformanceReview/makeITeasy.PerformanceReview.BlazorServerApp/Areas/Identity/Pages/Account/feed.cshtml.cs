using makeITeasy.PerformanceReview.Infrastructure.Data;
using makeITeasy.PerformanceReview.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Areas.Identity.Pages.Account
{

    public class feedModel : PageModel
    {
        private PeformanceReviewDbContext _dbContext { get; set; }
        private UserManager<AppUser> _userManager { get; set; }
        private IUserStore<AppUser> _userStore { get; set; }
        //private IUserEmailStore<IdentityUser> _emailStore { get; set; }

        public feedModel(PeformanceReviewDbContext context, UserManager<AppUser> userManager, IUserStore<AppUser> userStore/*, IUserEmailStore<IdentityUser> emailStore*/)
        {
            this._dbContext = context;
            _userManager = userManager;
            _userStore = userStore;
            //_emailStore = emailStore;q
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var adminUser = Activator.CreateInstance<AppUser>();
            adminUser.EmailConfirmed = true;
            adminUser.Email = "admin@x.com";
            adminUser.NormalizedEmail = "ADMIN@X.COM";
            await _userStore.SetUserNameAsync(adminUser, "admin@x.com", CancellationToken.None);
            //await _emailStore.SetEmailAsync(adminUser, "foo@bar.com", CancellationToken.None);
            var result = await _userManager.CreateAsync(adminUser, "xx");

            if (result.Succeeded)
            {

                var userId = await _userManager.GetUserIdAsync(adminUser);

                IdentityRole adminRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "admin", NormalizedName = "ADMIN" };
                IdentityRole employeeRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "employee", NormalizedName = "EMPLOYEE" };
                IdentityRole managerRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "manager", NormalizedName = "MANAGER" };

                _dbContext.Roles.Add(adminRole);
                _dbContext.Roles.Add(employeeRole);
                _dbContext.Roles.Add(managerRole);

                IdentityUserRole<string> adminUserRole = new IdentityUserRole<string>() { RoleId = adminRole.Id, UserId = userId };

                _dbContext.UserRoles.Add(adminUserRole);
            }
            _dbContext.SaveChanges();

            return Page();
        }
    }
}
