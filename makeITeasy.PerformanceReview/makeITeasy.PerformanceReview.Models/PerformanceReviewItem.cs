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
        public int PerformanceReviewCategoryId { get; set; }
        public string Description { get; set; } = null!;

        public virtual Employee IdNavigation { get; set; } = null!;
        public virtual PerformanceReviewForm PerformanceReview { get; set; } = null!;
        public virtual PerformanceReviewCategory PerformanceReviewCategory { get; set; } = null!;
        public virtual ICollection<PerformanceReviewEvaluationItem> PerformanceReviewEvaluationItems { get; set; }
    }
}
