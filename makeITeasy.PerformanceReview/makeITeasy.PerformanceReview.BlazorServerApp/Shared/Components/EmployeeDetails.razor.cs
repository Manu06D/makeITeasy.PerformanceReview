using Microsoft.AspNetCore.Components;

using static makeITeasy.PerformanceReview.BlazorServerApp.Pages.Employees;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components
{
    public partial class EmployeeDetails
    {
        [Parameter]
        public AppUserViewModel Employee { get; set; }
    }
}