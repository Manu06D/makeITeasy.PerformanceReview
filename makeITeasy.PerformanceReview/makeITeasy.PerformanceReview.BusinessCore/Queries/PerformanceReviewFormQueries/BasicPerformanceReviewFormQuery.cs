using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makeITeasy.PerformanceReview.BusinessCore.Queries.PerformanceReviewFormQueries
{
    public class BasicPerformanceReviewFormQuery : BaseTransactionQuery<Form>
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public override void BuildQuery()
        {
            if (ID.HasValue && ID.Value > 0)
            {
                AddFunctionToCriteria(x => x.Id == ID);
            }

            if (!string.IsNullOrEmpty(Name))
            {
                AddFunctionToCriteria(x => x.Name.Contains(Name));
            }
        }
    }
}
