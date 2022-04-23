using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class PerformanceReviewEvaluationItem : IBaseEntity
    {
        public int Id { get; set; }
        public int PerformanceReviewEvalutionId { get; set; }
        public int PerformanceReviewItemId { get; set; }

        public virtual PerformanceReviewEvalutation PerformanceReviewEvalution { get; set; } = null!;
        public virtual PerformanceReviewItem PerformanceReviewItem { get; set; } = null!;
    }
}
