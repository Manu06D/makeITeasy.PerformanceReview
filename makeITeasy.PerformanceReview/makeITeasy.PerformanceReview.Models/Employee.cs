﻿using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class Employee : IBaseEntity
    {
        public Employee()
        {
            Evaluations = new HashSet<Evaluation>();
        }

        public int Id { get; set; }
        public string UserIdentityId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string ManagerIdentityId { get; set; } = null!;

        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}
