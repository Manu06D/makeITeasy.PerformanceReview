using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.EvalutationQueries
{
    public class ManagerOrEmployeeEvaluationQuery : BaseTransactionQuery<Evaluation>
    {
        public string? IdentityId { get; set; }

        public override void BuildQuery()
        {
            if (!string.IsNullOrEmpty(IdentityId))
            {
                AddFunctionToCriteria(x => x.ManagerIdentityId == IdentityId);
                AddFunctionToCriteria(x => x.UserIdentityId == IdentityId, FunctionAggregatorEnum.Or);
            }
        }
    }
}
