using makeITeasy.AppFramework.Core.Interfaces;
using makeITeasy.AppFramework.Core.Services;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Services
{
    public class LevelService : BaseEntityService<Level>, ILevelService
    {
    }

    public interface ILevelService : IBaseEntityService<Level>
    {
    }
}
