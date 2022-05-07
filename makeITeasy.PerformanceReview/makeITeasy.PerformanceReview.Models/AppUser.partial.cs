using makeITeasy.AppFramework.Models;

using Microsoft.AspNetCore.Identity;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class AppUser : IdentityUser, IBaseEntity
    {
        public AppUser()
        {
            EmployeeManagerIdentities = new HashSet<Employee>();
            EvaluationItems = new HashSet<EvaluationItem>();
            EvaluationManagerIdentities = new HashSet<Evaluation>();
            EvaluationUserIdentities = new HashSet<Evaluation>();
            InverseManager = new HashSet<AppUser>();
        }

        public virtual AppUser? Manager { get; set; }
        public virtual Employee EmployeeUserIdentity { get; set; } = null!;
        public virtual ICollection<Employee> EmployeeManagerIdentities { get; set; }
        public virtual ICollection<EvaluationItem> EvaluationItems { get; set; }
        public virtual ICollection<Evaluation> EvaluationManagerIdentities { get; set; }
        public virtual ICollection<Evaluation> EvaluationUserIdentities { get; set; }
        public virtual ICollection<AppUser> InverseManager { get; set; }

        public object DatabaseID => Id;
        
        [PersonalData]
        public string? Name { get; set; }
        public string? ManagerId { get; set; }
    }
}
