using makeITeasy.AppFramework.Core.Interfaces;
using makeITeasy.AppFramework.Core.Services;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BusinessCore.Services
{
    public class EmployeeService : BaseEntityService<Employee>, IEmployeeService
    {
    }

    public interface IEmployeeService : IBaseEntityService<Employee>
    {
    }
}
