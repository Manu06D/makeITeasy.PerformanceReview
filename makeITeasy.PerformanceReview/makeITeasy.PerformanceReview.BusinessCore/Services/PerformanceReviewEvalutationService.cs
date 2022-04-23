using makeITeasy.AppFramework.Core.Interfaces;
using makeITeasy.AppFramework.Core.Services;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Services
{
    public class PerformanceReviewEvalutationService : BaseEntityService<PerformanceReviewEvalutation>, IPerformanceReviewEvalutationService
    {
    }

    public interface IPerformanceReviewEvalutationService : IBaseEntityService<PerformanceReviewEvalutation>
    {
    }
}
