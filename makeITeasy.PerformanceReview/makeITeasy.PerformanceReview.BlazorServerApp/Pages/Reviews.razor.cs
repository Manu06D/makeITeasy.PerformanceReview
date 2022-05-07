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

namespace makeITeasy.PerformanceReview.BlazorServerApp.Pages
{
    [Authorize(Roles = "admin,manager")]
    public partial class Reviews
    {
        public class EvalutationViewModel : IMapFrom<Evaluation>
        {
            public int Id { get; set; }

            public DateTime? CreationDate { get; set; }

            public string? UserIdentityName { get; set; }

            public void Mapping(AutoMapper.Profile profile)
            {
                if (profile != null)
                {
                    profile.CreateMap<Evaluation, EvalutationViewModel>();
                }
            }
        }

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationStateTask { get; set; }

        [Inject]
        private IDialogService? DialogService { get; set; }

        [Inject]
        private ISnackbar? Snackbar { get; set; }

        [Inject]
        private MediatR.IMediator? _mediator { get; set; }

        private GenericList<Evaluation, EvalutationViewModel, ManagerOrEmployeeEvaluationQuery>? table;
        private ManagerOrEmployeeEvaluationQuery? defaultQuery;

        private DialogOptions defaultDialogOptions = new() {CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true, DisableBackdropClick = false};

        protected override async Task OnInitializedAsync()
        {
            string? currentIdentityId = (await authenticationStateTask).User.GetIdentityUserID();
            defaultQuery = new ManagerOrEmployeeEvaluationQuery() { IdentityId = currentIdentityId,  };
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
            defaultDialogOptions.DisableBackdropClick = true;
            var dialog = DialogService.Show<ReviewEdit>(string.Empty, new DialogParameters()
            {["id"] = id}, defaultDialogOptions);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                int.TryParse(result.Data.ToString(), out int createdReview);
                Snackbar.Add($"Review Created (id:{createdReview})", Severity.Success);
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
                var result = await _mediator.Send(new DeleteEntityCommand<Evaluation>(new Evaluation() {Id = entity.Id}));
                if (result.Result == CommandState.Success)
                {
                    Snackbar.Add($"Review Deleted", Severity.Success);
                    await table.ReloadTableAsync();
                }
            }
        }
    }
}