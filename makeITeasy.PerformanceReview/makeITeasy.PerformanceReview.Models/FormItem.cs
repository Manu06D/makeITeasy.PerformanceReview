using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class FormItem : IBaseEntity
    {
        public FormItem()
        {
            EvaluationItems = new HashSet<EvaluationItem>();
        }

        public int Id { get; set; }
        public int FormId { get; set; }
        public string Description { get; set; } = null!;
        public string? Category { get; set; }
        public int? LevelId { get; set; }

        public virtual Form Form { get; set; } = null!;
        public virtual Level? Level { get; set; }
        public virtual ICollection<EvaluationItem> EvaluationItems { get; set; }
    }
}
