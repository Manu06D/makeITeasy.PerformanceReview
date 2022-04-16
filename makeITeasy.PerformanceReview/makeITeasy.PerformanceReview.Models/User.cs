using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class User : IBaseEntity
    {
        public User()
        {
            PerformanceReviewMains = new HashSet<PerformanceReviewMain>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PerformanceReviewMain> PerformanceReviewMains { get; set; }
    }
}
