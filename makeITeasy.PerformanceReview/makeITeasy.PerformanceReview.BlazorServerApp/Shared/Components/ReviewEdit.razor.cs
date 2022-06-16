using Microsoft.AspNetCore.Components;
using MudBlazor;
using makeITeasy.PerformanceReview.Models;
using Microsoft.AspNetCore.Components.Authorization;
using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Extensions;
using makeITeasy.AppFramework.Core.Commands;
using makeITeasy.PerformanceReview.BusinessCore.Queries.EvalutationQueries;
using makeITeasy.PerformanceReview.BusinessCore.Queries.LevelQueries;

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

        public class MyLevelIdComparer : Comparer<Level>{ public override int Compare(Level x, Level y) { return x.Id.CompareTo(y.Id); } }

        protected override async Task OnInitializedAsync()
        {
            currentClaims = (await authenticationStateTask).User;

            currentIdentityUserID = currentClaims.GetIdentityUserID();

            evaluation = (await _mediator.Send(new AppFramework.Core.Queries.GenericQueryCommand<Evaluation>(new EditEvalutationQuery(Id), false))).Results.FirstOrDefault();

            if (evaluation?.UserIdentity?.LevelId.HasValue == true && evaluation.Form.FormItems.Any(x => x.LevelId.HasValue))
            {
                List<Level>? allLevels = (await _mediator.Send(new AppFramework.Core.Queries.GenericQueryCommand<Level>(new BasicLevelQuery(), false))).Results.OrderBy(x => x.Index).ToList();

                int levelIndex = allLevels.BinarySearch(new Level() { Id = evaluation?.UserIdentity?.LevelId.Value ?? -1 }, new MyLevelIdComparer());

                if(levelIndex >= 0)
                {
                    List<int> acceptedLevel = allLevels.GetRange(Math.Max(0, levelIndex - 2), levelIndex).Select(x => x.Id).ToList();
                    acceptedLevel.AddRange(allLevels.GetRange(levelIndex, Math.Min(allLevels.Count, levelIndex + 2)).Select(x => x.Id).ToList());
                    //int minLevel = allLevels[Math.Max(0, levelIndex - 2)].Index;
                    //int maxLevel = allLevels[Math.Min(allLevels.Count, levelIndex + 2)].Index;

                    evaluation.Form.FormItems = evaluation.Form.FormItems.Where(x => !x.LevelId.HasValue || acceptedLevel.Contains(x.LevelId.Value)).ToList();
                }
            }

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