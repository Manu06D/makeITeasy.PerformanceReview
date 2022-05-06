using System;
using System.Collections.Generic;
using makeITeasy.AppFramework.Models;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class Evaluation : ITimeTrackingEntity
    {
        public object DatabaseID => Id;
    }
}
