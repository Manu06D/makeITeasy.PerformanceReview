using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class User : IBaseEntity
    {
        public User()
        {
            PerformanceReviewEvalutations = new HashSet<PerformanceReviewEvalutation>();
            PerformanceReviewForms = new HashSet<PerformanceReviewForm>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PerformanceReviewEvalutation> PerformanceReviewEvalutations { get; set; }
        public virtual ICollection<PerformanceReviewForm> PerformanceReviewForms { get; set; }
    }
}
