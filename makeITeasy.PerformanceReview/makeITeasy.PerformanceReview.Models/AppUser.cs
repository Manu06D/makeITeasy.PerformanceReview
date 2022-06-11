using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class AppUser : IBaseEntity
    {
        public AppUser()
        {
            EmployeeManagerIdentities = new HashSet<Employee>();
            EvaluationItems = new HashSet<EvaluationItem>();
            EvaluationManagerIdentities = new HashSet<Evaluation>();
            EvaluationUserIdentities = new HashSet<Evaluation>();
            InverseManager = new HashSet<AppUser>();
        }

        public int? LevelId { get; set; }
        public int? FirstYearOfWork { get; set; }
        public string? Education { get; set; }

        public virtual Level? Level { get; set; }
        public virtual AppUser? Manager { get; set; }
        public virtual Employee EmployeeUserIdentity { get; set; } = null!;
        public virtual ICollection<Employee> EmployeeManagerIdentities { get; set; }
        public virtual ICollection<EvaluationItem> EvaluationItems { get; set; }
        public virtual ICollection<Evaluation> EvaluationManagerIdentities { get; set; }
        public virtual ICollection<Evaluation> EvaluationUserIdentities { get; set; }
        public virtual ICollection<AppUser> InverseManager { get; set; }
    }
}
