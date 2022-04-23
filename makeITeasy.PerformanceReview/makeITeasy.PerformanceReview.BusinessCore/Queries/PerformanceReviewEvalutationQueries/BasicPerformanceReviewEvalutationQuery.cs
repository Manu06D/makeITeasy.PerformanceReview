using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.PerformanceReviewEvalutationQueries
{
    public class BasicPerformanceReviewEvalutationQuery : BaseTransactionQuery<PerformanceReviewEvalutation>
    {
        public int? ID { get; set; }

        public override void BuildQuery()
        {
            if (ID.HasValue && ID.Value > 0)
            {
                AddFunctionToCriteria(x => x.Id == ID);
            }
        }
    }
}
