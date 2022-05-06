using makeITeasy.AppFramework.Core.Interfaces;
using makeITeasy.AppFramework.Core.Services;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Services
{
    public class EvalutationService : BaseEntityService<Evaluation>, IEvalutationService
    {
    }

    public interface IEvalutationService : IBaseEntityService<Evaluation>
    {
    }
}
