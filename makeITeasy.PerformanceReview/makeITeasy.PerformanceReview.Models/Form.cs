using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class Form : IBaseEntity
    {
        public Form()
        {
            Evaluations = new HashSet<Evaluation>();
            FormItems = new HashSet<FormItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<FormItem> FormItems { get; set; }
    }
}
