﻿using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.PerformanceReviewEvalutationQueries
{
    public class BasicPerformanceReviewEvalutationQuery : BaseTransactionQuery<Evaluation>
    {
        public int? ID { get; set; }
        public string? ManagerId { get; set; }

        public override void BuildQuery()
        {
            if (ID.HasValue && ID.Value > 0)
            {
                AddFunctionToCriteria(x => x.Id == ID);
            }

            if (!string.IsNullOrEmpty(ManagerId))
            {
                AddFunctionToCriteria(x => x.UserIdentity.ManagerIdentityId == ManagerId);
            }
        }
    }
}
