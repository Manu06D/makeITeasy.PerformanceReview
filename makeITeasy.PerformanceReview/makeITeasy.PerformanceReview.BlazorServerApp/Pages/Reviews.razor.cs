using Microsoft.AspNetCore.Components;
using MudBlazor;
using makeITeasy.AppFramework.Core.Commands;
using makeITeasy.AppFramework.Core.Interfaces;
using makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components;
using makeITeasy.PerformanceReview.Models;
using Microsoft.AspNetCore.Components.Authorization;
using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Extensions;
using Microsoft.AspNetCore.Authorization;
using makeITeasy.PerformanceReview.BusinessCore.Queries.EvalutationQueries;
using static makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components.ReviewEdit;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Pages
{
    [Authorize]
    public partial class Reviews
    {
        public class EvalutationViewModel : IMapFrom<Evaluation>
        {
            public int Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public string? UserIdentityName { get; set; }
            public string? FormName { get; set; }
            public EvaluationState? State { get; set; }
            public bool FilledByManager { get; set; }
            public bool FilledByEmployee { get; set; }
            public bool IsReviewed { get; set; }
            public bool IsFilled => FilledByEmployee && FilledByManager;
        }

        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationStateTask { get; set; }

        [Inject]
        private IDialogService? DialogService { get; set; }
        [Inject]
        private ISnackbar? Snackbar { get; set; }
        [Inject]
        private MediatR.IMediator? Mediator { get; set; }

        private System.Security.Claims.ClaimsPrincipal? currentClaims;
        private GenericList<Evaluation, EvalutationViewModel, ManagerOrEmployeeEvaluationQuery>? table;
        private ManagerOrEmployeeEvaluationQuery? defaultQuery;
        private DialogOptions defaultDialogOptions = new() {CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true, DisableBackdropClick = false};

        protected override async Task OnInitializedAsync()
        {
            currentClaims = (await AuthenticationStateTask).User;

            defaultQuery = new ManagerOrEmployeeEvaluationQuery() { IdentityId = currentClaims.GetIdentityUserID() };
        }

        private async Task CreateNewAsync()
        {
            var dialog = DialogService?.Show<ReviewCreate>("Creating new Review", defaultDialogOptions);
            if (dialog != null)
            {
                DialogResult result = await dialog.Result;

                if (!result.Cancelled)
                {
                    _ = int.TryParse(result.Data.ToString(), out int createdReview);
                    Snackbar?.Add($"Review Created (id:{createdReview})", Severity.Success);
                    await table.ReloadTableAsync();
                }
            }
        }

        private async Task Edit(int id)
        {
            await openReviewDialogAsync(id, ReviewEditMode.Edit);
        }
        private async Task Review(int id)
        {
            await openReviewDialogAsync(id, ReviewEditMode.Review);
        }

        private async Task openReviewDialogAsync(int id, ReviewEditMode mode)
        {
            defaultDialogOptions.DisableBackdropClick = true;
            var dialog = DialogService.Show<ReviewEdit>(string.Empty, new DialogParameters() { ["id"] = id, ["Mode"] = mode }, defaultDialogOptions);

            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                Snackbar.Add($"Review updated", Severity.Success);
                await table.ReloadTableAsync();
            }
        }

        private async Task DeleteAsync(Evaluation entity)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to delete these records? This process cannot be undone.");
            parameters.Add("ButtonText", "Delete");
            parameters.Add("Color", Color.Error);
            var options = new DialogOptions()
            {CloseButton = true, MaxWidth = MaxWidth.ExtraSmall};
            var dialog = DialogService.Show<ConfirmDialog>("Delete", parameters, options);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Cancelled)
            {
                var result = await Mediator.Send(new DeleteEntityCommand<Evaluation>(new Evaluation() {Id = entity.Id}));
                if (result.Result == CommandState.Success)
                {
                    Snackbar.Add($"Review Deleted", Severity.Success);
                    await table.ReloadTableAsync();
                }
            }
        }
    }
}