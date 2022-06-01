using Microsoft.AspNetCore.Components;
using makeITeasy.PerformanceReview.Models;
using static makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components.ReviewEdit;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components
{
    public partial class ReviewItemEdit
    {
        [Parameter]
        public FormItem Model { get; set; }

        [Parameter]
        public Evaluation Evaluation { get; set; }

        [Parameter]
        public String CurrentIdentityUserID { get; set; }

        [Parameter]
        public bool IsEmployee { get; set; }

        [Parameter]
        public ReviewEditMode Mode { get; set; }
    }
}