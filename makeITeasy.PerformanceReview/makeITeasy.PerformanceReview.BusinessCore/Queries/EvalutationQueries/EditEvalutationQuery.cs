using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.EvalutationQueries
{
    public class EditEvalutationQuery : BaseTransactionQuery<Evaluation>
    {
        private readonly int id;

        public EditEvalutationQuery(int Id)
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
