using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class PerformanceReviewMain : IBaseEntity
    {
        public PerformanceReviewMain()
        {
            PerformanceReviewCategories = new HashSet<PerformanceReviewCategory>();
            PerformanceReviewItems = new HashSet<PerformanceReviewItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PerformanceReviewCategory> PerformanceReviewCategories { get; set; }
        public virtual ICollection<PerformanceReviewItem> PerformanceReviewItems { get; set; }
    }
}
