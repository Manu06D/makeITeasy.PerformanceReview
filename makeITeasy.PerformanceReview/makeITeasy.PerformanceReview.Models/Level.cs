using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class Level : IBaseEntity
    {
        public Level()
        {
            AppUsers = new HashSet<AppUser>();
            FormItems = new HashSet<FormItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Index { get; set; }

        public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual ICollection<FormItem> FormItems { get; set; }
    }
}
