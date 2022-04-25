using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.PerformanceReviewEvalutationQueries
{
    public class EditPerformanceReviewEvalutationQuery : BaseTransactionQuery<PerformanceReviewEvalutation>
    {
        private readonly int id;

        public EditPerformanceReviewEvalutationQuery(int Id)
        {
            id = Id;
        }

        public override void BuildQuery()
        {
            AddFunctionToCriteria(x => x.Id == id);
            AddInclude(x => x.Employee);
            AddInclude(x => x.PerformanceReviewForm.PerformanceReviewItems);
            AddInclude(x => x.PerformanceReviewEvaluationItems);
        }
    }
}
