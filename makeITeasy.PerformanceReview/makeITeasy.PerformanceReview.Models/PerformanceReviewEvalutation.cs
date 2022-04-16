using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class PerformanceReviewEvalutation : IBaseEntity
    {
        public PerformanceReviewEvalutation()
        {
            PerformanceReviewEvaluationItems = new HashSet<PerformanceReviewEvaluationItem>();
        }

        public int Id { get; set; }
        public int PerformanceReviewId { get; set; }

        public virtual ICollection<PerformanceReviewEvaluationItem> PerformanceReviewEvaluationItems { get; set; }
    }
}
