using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.PerformanceReviewEvalutationQueries
{
    public class ManagerOrEmployeePerformanceReviewEvaluationQuery : BaseTransactionQuery<Evaluation>
    {
        public string IdentityId { get; set; }

        public override void BuildQuery()
        {
            if (!string.IsNullOrEmpty(IdentityId))
            {
                AddFunctionToCriteria(x => x.UserIdentity.ManagerIdentityId == IdentityId);
                AddFunctionToCriteria(x => x.UserIdentity.UserIdentityId == IdentityId, FunctionAggregatorEnum.Or);
            }

        }
    }
}
