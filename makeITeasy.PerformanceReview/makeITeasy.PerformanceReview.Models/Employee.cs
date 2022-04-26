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
        public string Name { get; set; } = null!;
        public string ManagerId { get; set; } = null!;
        public string? UserIdentityId { get; set; }

        public virtual ICollection<PerformanceReviewEvalutation> PerformanceReviewEvalutations { get; set; }
    }
}
