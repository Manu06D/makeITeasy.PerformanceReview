using Microsoft.AspNetCore.Components;
using MudBlazor;
using makeITeasy.AppFramework.Core.Commands;
using makeITeasy.AppFramework.Core.Queries;
using makeITeasy.PerformanceReview.BusinessCore.Queries.PerformanceReviewFormQueries;
using makeITeasy.PerformanceReview.Models;
using Microsoft.AspNetCore.Components.Authorization;
using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Extensions;
using makeITeasy.PerformanceReview.BusinessCore.Queries.UserQueries;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components
{
    public partial class ReviewCreate
    {
        [CascadingParameter]
        private Task<AuthenticationState>? authenticationStateTask { get; set; }

        [Inject]
        private MediatR.IMediator? _mediator { get; set; }

        [Inject]
        ISnackbar? Snackbar { get; set; }

        [CascadingParameter]
        MudDialogInstance? MudDialog { get; set; }

        private bool success;
        private bool _processing = false;

        private IList<AppUser> users = new List<AppUser>();
        private IList<Form> forms = new List<Form>();
        private Form selectedForm;
        private AppUser selectedUser;
        private string? currentIdentityUserID;

        protected override async Task OnInitializedAsync()
        {
            currentIdentityUserID = (await authenticationStateTask).User.GetIdentityUserID();

            if (_mediator != null)
            {
                users = (await _mediator.Send(new GenericQueryCommand<AppUser>(new BasicAppUserQuery() { ManagerIdentityId = currentIdentityUserID }))).Results;
                forms = (await _mediator.Send(new GenericQueryCommand<Form>(new BasicPerformanceReviewFormQuery()))).Results;
            }
        }

        private async Task Create()
        {
            _processing = true;

            var result = 
                await _mediator.Send(new CreateEntityCommand<Evaluation>(
                    new Evaluation()
                    { 
                                FormId = selectedForm.Id, ManagerIdentityId = currentIdentityUserID, UserIdentityId = selectedUser.Id 
                    }));

            if (result.Result == CommandState.Success)
            {
                MudDialog?.Close(DialogResult.Ok(result.Entity.Id));
            }
            else
            {
                //TODO Manage errors
                _processing = false;
            }
        }
    }
}