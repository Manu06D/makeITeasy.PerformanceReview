using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.EmployeeQueries
{
    public class BasicEmployeeQuery : BaseTransactionQuery<Employee>
    {
        public int? ID { get; set; }

        public string ManagerId { get; set; }

        public string UserIdentityId { get; set; }

        public override void BuildQuery()
        {
            if (ID.HasValue && ID.Value > 0)
            {
                AddFunctionToCriteria(x => x.Id == ID);
            }
            
            if(!string.IsNullOrEmpty(ManagerId))
            {
                AddFunctionToCriteria(x => x.ManagerId == ManagerId);
            }

            if (!string.IsNullOrEmpty(UserIdentityId))
            {
                AddFunctionToCriteria(x => x.UserIdentityId == UserIdentityId);
            }
        }
    }
}
