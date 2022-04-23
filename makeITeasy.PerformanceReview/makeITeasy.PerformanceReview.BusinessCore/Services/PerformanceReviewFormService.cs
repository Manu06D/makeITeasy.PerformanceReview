﻿using makeITeasy.AppFramework.Core.Interfaces;
using makeITeasy.AppFramework.Core.Services;
using makeITeasy.PerformanceReview.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makeITeasy.PerformanceReview.BusinessCore.Services
{
    public class PerformanceReviewFormService : BaseEntityService<PerformanceReviewForm>,  IPerformanceReviewFormService
    {
    }

    public interface IPerformanceReviewFormService : IBaseEntityService<PerformanceReviewForm>
    {
    }
}
