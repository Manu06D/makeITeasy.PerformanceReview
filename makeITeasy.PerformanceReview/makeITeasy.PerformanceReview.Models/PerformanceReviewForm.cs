using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class PerformanceReviewForm : IBaseEntity
    {
        public PerformanceReviewForm()
        {
            PerformanceReviewCategories = new HashSet<PerformanceReviewCategory>();
            PerformanceReviewEvalutations = new HashSet<PerformanceReviewEvalutation>();
            PerformanceReviewItems = new HashSet<PerformanceReviewItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<PerformanceReviewCategory> PerformanceReviewCategories { get; set; }
        public virtual ICollection<PerformanceReviewEvalutation> PerformanceReviewEvalutations { get; set; }
        public virtual ICollection<PerformanceReviewItem> PerformanceReviewItems { get; set; }
    }
}
