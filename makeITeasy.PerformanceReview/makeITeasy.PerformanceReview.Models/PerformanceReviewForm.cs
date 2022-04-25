using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class PerformanceReviewForm : IBaseEntity
    {
        public PerformanceReviewForm()
        {
            PerformanceReviewEvalutations = new HashSet<PerformanceReviewEvalutation>();
            PerformanceReviewItems = new HashSet<PerformanceReviewItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PerformanceReviewEvalutation> PerformanceReviewEvalutations { get; set; }
        public virtual ICollection<PerformanceReviewItem> PerformanceReviewItems { get; set; }
    }
}
