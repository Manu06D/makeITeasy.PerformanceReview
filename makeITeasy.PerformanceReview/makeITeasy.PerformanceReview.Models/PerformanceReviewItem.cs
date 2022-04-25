using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class PerformanceReviewItem : IBaseEntity
    {
        public PerformanceReviewItem()
        {
            PerformanceReviewEvaluationItems = new HashSet<PerformanceReviewEvaluationItem>();
        }

        public int Id { get; set; }
        public int PerformanceReviewId { get; set; }
        public string Description { get; set; } = null!;
        public string? Category { get; set; }

        public virtual PerformanceReviewForm PerformanceReview { get; set; } = null!;
        public virtual ICollection<PerformanceReviewEvaluationItem> PerformanceReviewEvaluationItems { get; set; }
    }
}
