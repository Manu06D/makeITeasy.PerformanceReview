using makeITeasy.PerformanceReview.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makeITeasy.PerformanceReview.Infrastructure.Data.Configurations
{
    public partial class AppUserConfiguration
    {
        partial void OnConfigurePartial(EntityTypeBuilder<AppUser> entity)
        {
            entity.HasKey(e => e.Id);
        }
    }
}
