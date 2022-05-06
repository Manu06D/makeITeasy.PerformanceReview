using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.EmployeeQueries
{
    public class BasicEmployeeQuery : BaseTransactionQuery<Employee>
    {
        public int? ID { get; set; }

        public string UserIdentityId { get; set; }

        public List<string> UserIdentitiesId { get; set; }

        public string UserManagerIdentityId { get; set; }

        public override void BuildQuery()
        {
            if (ID.HasValue && ID.Value > 0)
            {
                AddFunctionToCriteria(x => x.Id == ID);
            }
            
            if (!string.IsNullOrEmpty(UserIdentityId))
            {
                AddFunctionToCriteria(x => x.UserIdentityId == UserIdentityId);
            }

            if (!string.IsNullOrEmpty(UserManagerIdentityId))
            {
                AddFunctionToCriteria(x => x.ManagerIdentityId == UserManagerIdentityId);
            }

            if (UserIdentitiesId?.Count > 0)
            {
                AddFunctionToCriteria(x => UserIdentitiesId.Contains(x.UserIdentityId));
            }
        }
    }
}
