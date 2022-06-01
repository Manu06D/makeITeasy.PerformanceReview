using Microsoft.AspNetCore.Components;
using MudBlazor;
using makeITeasy.PerformanceReview.Models;
using Microsoft.AspNetCore.Components.Authorization;
using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Extensions;
using makeITeasy.AppFramework.Core.Commands;
using makeITeasy.PerformanceReview.BusinessCore.Queries.EvalutationQueries;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components
{
    public partial class ReviewEdit
    {
        public enum ReviewEditMode
        {
            Edit,
            Review
        }

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationStateTask { get; set; }

        [CascadingParameter]
        MudDialogInstance? MudDialog { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public ReviewEditMode Mode { get; set; }

        [Inject]
        private MediatR.IMediator? _mediator { get; set; }

        [Inject]
        private ISnackbar? Snackbar { get; set; }

        private Evaluation? evaluation;
        private string? currentIdentityUserID;
        private System.Security.Claims.ClaimsPrincipal? currentClaims;

        private TableGroupDefinition<FormItem> _groupDefinition = new() { GroupName = "Group", Indentation = false, Expandable = true, Selector = (e) => e.Category };


        protected override async Task OnInitializedAsync()
        {
            currentClaims = (await authenticationStateTask).User;

            currentIdentityUserID = currentClaims.GetIdentityUserID();

            evaluation = (await _mediator.Send(new AppFramework.Core.Queries.GenericQueryCommand<Evaluation>(
                new EditEvalutationQuery(Id), false))).Results.FirstOrDefault();

            foreach (var items in evaluation.Form.FormItems)
            {
                if (!evaluation.EvaluationItems.Any(x => x.FormItemId == items.Id && x.UserIdentityId == evaluation.UserIdentityId))
                {
                    evaluation.EvaluationItems.Add(new EvaluationItem() { FormItemId = items.Id, UserIdentityId = evaluation?.UserIdentityId, EvaluationId = evaluation.Id, Rating = -1 });
                }

                if (!evaluation.EvaluationItems.Any(x => x.FormItemId == items.Id && x.UserIdentityId == evaluation.ManagerIdentityId))
                {
                    evaluation.EvaluationItems.Add(new EvaluationItem() { FormItemId = items.Id, UserIdentityId = evaluation?.ManagerIdentityId, EvaluationId = evaluation.Id, Rating = -1 });
                }
            }


            if (evaluation == null)
            {
                throw new Exception($"Evalution not found with id : {Id}");
            }
            else
            {
                MudDialog.SetTitle("Evaluation Review for : " + evaluation.UserIdentity.Name);
            }
        }

        private async Task Update()
        {
            foreach (var evaluationItem in evaluation.EvaluationItems)
            {
                if (evaluationItem.UserIdentityId == currentIdentityUserID && evaluationItem.Rating >= 0 && _mediator != null)
                {
                    if (evaluationItem.Id == 0)
                    {
                        var _ = await _mediator.Send(new CreateEntityCommand<EvaluationItem>(evaluationItem));
                    }
                    else
                    {
                        var _ = await _mediator.Send(new UpdateEntityCommand<EvaluationItem>(evaluationItem));
                    }
                }
            }

            MudDialog?.Close(DialogResult.Ok(true));
        }

        private async Task Validate()
        {
            evaluation.State = EvaluationState.Reviewed;

            var updateEvaluationResult = await _mediator.Send(new UpdatePartialEntityCommand<Evaluation>(evaluation, new string[] { nameof(evaluation.State) }));

            MudDialog?.Close();
        }
    }
}