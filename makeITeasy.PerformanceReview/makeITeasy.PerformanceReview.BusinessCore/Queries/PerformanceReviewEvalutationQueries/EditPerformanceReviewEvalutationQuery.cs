using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.PerformanceReviewEvalutationQueries
{
    public class EditPerformanceReviewEvalutationQuery : BaseTransactionQuery<Evaluation>
    {
        private readonly int id;

        public EditPerformanceReviewEvalutationQuery(int Id)
        {
            id = Id;
        }

        public override void BuildQuery()
        {
            AddFunctionToCriteria(x => x.Id == id);
            AddInclude(x => x.UserIdentity);
            AddInclude(x => x.Form.FormItems);
            AddInclude(x => x.EvaluationItems);
        }
    }
}
