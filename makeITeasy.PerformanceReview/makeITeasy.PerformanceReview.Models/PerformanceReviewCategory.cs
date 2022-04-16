using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class PerformanceReviewCategory : IBaseEntity
    {
        public PerformanceReviewCategory()
        {
            PerformanceReviewItems = new HashSet<PerformanceReviewItem>();
        }

        public int Id { get; set; }
        public int PerformanceReviewId { get; set; }
        public string Name { get; set; }

        public virtual PerformanceReviewMain PerformanceReview { get; set; }
        public virtual ICollection<PerformanceReviewItem> PerformanceReviewItems { get; set; }
    }
}
