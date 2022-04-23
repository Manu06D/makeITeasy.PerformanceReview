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
        public int PerformanceReviewFormId { get; set; }
        public int? EmployeeId { get; set; }
        public int? UserId { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual PerformanceReviewForm PerformanceReviewForm { get; set; } = null!;
        public virtual User? User { get; set; }
        public virtual ICollection<PerformanceReviewEvaluationItem> PerformanceReviewEvaluationItems { get; set; }
    }
}
