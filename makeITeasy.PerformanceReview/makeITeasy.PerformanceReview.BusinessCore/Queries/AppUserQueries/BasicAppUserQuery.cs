using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.UserQueries
{
    public class BasicAppUserQuery : BaseTransactionQuery<AppUser>
    {
        public string? Id { get; set; }
        public string? ManagerIdentityId { get; set; }

        public override void BuildQuery()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                AddFunctionToCriteria(x => x.Id == Id);
            }

            if (!string.IsNullOrEmpty(ManagerIdentityId))
            {
                AddFunctionToCriteria(x => x.ManagerId == ManagerIdentityId);
            }
        }
    }
}
