using makeITeasy.AppFramework.Core.Interfaces;
using makeITeasy.AppFramework.Core.Services;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Services
{
    public class AppUserService : BaseEntityService<AppUser>, IAppUserService
    {
    }

    public interface IAppUserService : IBaseEntityService<AppUser>
    {
    }
}
