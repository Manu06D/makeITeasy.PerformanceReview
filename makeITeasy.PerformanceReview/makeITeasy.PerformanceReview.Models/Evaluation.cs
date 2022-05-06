using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class Evaluation : IBaseEntity
    {
        public Evaluation()
        {
            EvaluationItems = new HashSet<EvaluationItem>();
        }

        public int Id { get; set; }
        public int FormId { get; set; }
        public string? UserIdentityId { get; set; }
        public string? ManagerIdentityId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }

        public virtual Form Form { get; set; } = null!;
        public virtual Employee? UserIdentity { get; set; }
        public virtual ICollection<EvaluationItem> EvaluationItems { get; set; }
    }
}
