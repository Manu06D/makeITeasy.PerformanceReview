using AutoMapper;

using makeITeasy.AppFramework.Infrastructure.EF6.Persistence;
using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.Infrastructure.Data;

namespace makeITeasy.PerformanceReview.Infrastructure
{
    public class PeformanceReviewCatalogRepository<T> : BaseEfRepository<T, PeformanceReviewDbContext> where T : class, IBaseEntity
    {
        public PeformanceReviewCatalogRepository(PeformanceReviewDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
