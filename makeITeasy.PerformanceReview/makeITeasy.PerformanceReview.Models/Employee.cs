using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class Employee : IBaseEntity
    {
        public Employee()
        {
            PerformanceReviewEvalutations = new HashSet<PerformanceReviewEvalutation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? EmailAddress { get; set; }

        public virtual PerformanceReviewItem PerformanceReviewItem { get; set; } = null!;
        public virtual ICollection<PerformanceReviewEvalutation> PerformanceReviewEvalutations { get; set; }
    }
}
