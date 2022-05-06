using Microsoft.AspNetCore.Components;
using MudBlazor;
using makeITeasy.AppFramework.Core.Commands;
using makeITeasy.AppFramework.Core.Queries;
using makeITeasy.PerformanceReview.BusinessCore.Queries.EmployeeQueries;
using makeITeasy.PerformanceReview.BusinessCore.Queries.PerformanceReviewFormQueries;
using makeITeasy.PerformanceReview.Models;
using Microsoft.AspNetCore.Components.Authorization;
using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Extensions;

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

        private MudForm? form;
        private bool success;
        private bool _processing = false;

        private IList<Employee> employees = new List<Employee>();
        private IList<Form> forms = new List<Form>();
        private Form selectedForm;
        private Employee selectedEmployee;
        private string? currentIdentityUserID;

        protected override async Task OnInitializedAsync()
        {
            currentIdentityUserID = (await authenticationStateTask).User.GetIdentityUserID();

            employees = (await _mediator.Send(new GenericQueryCommand<Employee>(new BasicEmployeeQuery() { UserManagerIdentityId = currentIdentityUserID }))).Results;
            forms = (await _mediator.Send(new GenericQueryCommand<Form>(new BasicPerformanceReviewFormQuery()))).Results;
        }

        private async Task Create()
        {
            _processing = true;

            var result = await _mediator.Send(new CreateEntityCommand<Evaluation>(new Evaluation()
                        {FormId = selectedForm.Id, ManagerIdentityId = currentIdentityUserID, UserIdentityId = selectedEmployee.UserIdentityId }));

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