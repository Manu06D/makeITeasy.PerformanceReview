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
        public string Description { get; set; }

        public virtual PerformanceReviewMain PerformanceReview { get; set; }
        public virtual PerformanceReviewCategory PerformanceReviewCategory { get; set; }
        public virtual ICollection<PerformanceReviewEvaluationItem> PerformanceReviewEvaluationItems { get; set; }
    }
}
