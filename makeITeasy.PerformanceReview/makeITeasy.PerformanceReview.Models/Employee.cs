using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class Employee : IBaseEntity
    {
        public int Id { get; set; }
        public string UserIdentityId { get; set; } = null!;
        public string ManagerIdentityId { get; set; } = null!;

        public virtual AppUser ManagerIdentity { get; set; } = null!;
        public virtual AppUser UserIdentity { get; set; } = null!;
    }
}
