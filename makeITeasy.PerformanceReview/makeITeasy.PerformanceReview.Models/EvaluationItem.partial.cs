using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class EvaluationItem : ITimeTrackingEntity
    {
        public object DatabaseID => Id;
    }
}
