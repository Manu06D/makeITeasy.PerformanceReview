using makeITeasy.AppFramework.Core.Interfaces;
using makeITeasy.AppFramework.Core.Services;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Services
{
    public class EvaluationItemService : BaseEntityService<EvaluationItem>, IEvaluationItemService
    {
    }

    public interface IEvaluationItemService : IBaseEntityService<EvaluationItem>
    {
    }
}
