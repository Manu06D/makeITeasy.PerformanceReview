using makeITeasy.AppFramework.Models;

using Microsoft.AspNetCore.Identity;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class AppUser : IdentityUser, IBaseEntity
    {
        public object DatabaseID => Id;
        
        [PersonalData]
        public string? Name { get; set; }
        public string? ManagerId { get; set; }
    }
}
