using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class EvaluationItem : IBaseEntity
    {
        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public int FormItemId { get; set; }
        public string UserIdentityId { get; set; } = null!;
        public int Rating { get; set; }

        public virtual Evaluation Evaluation { get; set; } = null!;
        public virtual FormItem FormItem { get; set; } = null!;
    }
}
