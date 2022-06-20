using Microsoft.AspNetCore.Components;

namespace makeITeasy.PerformanceReview.BlazorServerApp
{
    public partial class App
    {
        [Parameter]
        public string? AntiforgeryToken { get; set; }

        [Inject]
        private makeITeasy.PerformanceReview.BlazorServerApp.Modules.Security.TokenProvider tokenProvider { get; set; }

        protected override Task OnInitializedAsync()
        {
            tokenProvider.AntiforgeryToken = AntiforgeryToken;
            return base.OnInitializedAsync();
        }
    }
}