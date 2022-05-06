using Microsoft.AspNetCore.Components;
using MudBlazor;
using makeITeasy.PerformanceReview.BusinessCore.Queries.PerformanceReviewEvalutationQueries;
using makeITeasy.PerformanceReview.Models;
using Microsoft.AspNetCore.Components.Authorization;
using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Extensions;
using System.Security.Claims;
using makeITeasy.AppFramework.Core.Commands;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components
{
    public partial class ReviewEdit
    {
        [CascadingParameter]
        private Task<AuthenticationState>? authenticationStateTask { get; set; }

        [CascadingParameter] 
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Inject]
        private MediatR.IMediator? _mediator { get; set; }

        private Evaluation? evaluation;
        private string? currentIdentityUserID;
        private IList<string>? currentUserRoles;
        private TableGroupDefinition<FormItem> _groupDefinition = new() {GroupName = "Group", Indentation = false, Expandable = true, Selector = (e) => e.Category};
        

        protected override async Task OnInitializedAsync()
        {
            var currentClaims = (await authenticationStateTask).User;
            currentIdentityUserID = currentClaims.GetIdentityUserID();
            currentUserRoles = currentClaims.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

            evaluation = (await _mediator.Send(new AppFramework.Core.Queries.GenericQueryCommand<Evaluation>(
                new EditPerformanceReviewEvalutationQuery(Id), false))).Results.FirstOrDefault();

            foreach(var items in evaluation.Form.FormItems)
            {
                if(! evaluation.EvaluationItems.Any(x => x.FormItemId == items.Id && x.UserIdentityId == evaluation.UserIdentityId))
                {
                    evaluation.EvaluationItems.Add(new EvaluationItem() { FormItemId = items.Id, UserIdentityId = evaluation.UserIdentityId, EvaluationId = evaluation.Id, Rating = -1 });
                }

                if (!evaluation.EvaluationItems.Any(x => x.FormItemId == items.Id && x.UserIdentityId == evaluation.ManagerIdentityId))
                {
                    evaluation.EvaluationItems.Add(new EvaluationItem() { FormItemId = items.Id, UserIdentityId = evaluation.ManagerIdentityId, EvaluationId = evaluation.Id, Rating = -1 });
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
            foreach(var evaluationItem in evaluation.EvaluationItems)
            {
                if(evaluationItem.UserIdentityId == currentIdentityUserID && evaluationItem.Rating >= 0)
                {
                    if(evaluationItem.Id == 0)
                    {
                        var results = await _mediator.Send(new CreateEntityCommand<EvaluationItem>(evaluationItem));
                    }
                    else
                    {
                        var results = await _mediator.Send(new UpdateEntityCommand<EvaluationItem>(evaluationItem));
                    }
                    //save me
                    string s = "";
                }
            }
        }
    }
}