using System;
using System.Collections.Generic;

using DelegateDecompiler;

using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class Evaluation : ITimeTrackingEntity
    {
        public object DatabaseID => Id;

        public EvaluationState State { get; set; } = EvaluationState.Open;

        public bool CanEdit => State == EvaluationState.Open;

        public bool CanReview => State == EvaluationState.Open && FilledByManager;

        [Computed]
        public bool FilledByManager => EvaluationItems?.Any(x => x.UserIdentityId == ManagerIdentityId) ?? false;

        [Computed]
        public bool FilledByEmployee => EvaluationItems?.Any(x => x.UserIdentityId == UserIdentityId) ?? false;

        //[Computed]
        //public bool IsReviewed => State == EvaluationState.Reviewed;

    }
}
