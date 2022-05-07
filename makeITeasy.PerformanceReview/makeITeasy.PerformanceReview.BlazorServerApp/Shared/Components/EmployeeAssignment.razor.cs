using Microsoft.AspNetCore.Components;
using MudBlazor;
using Microsoft.AspNetCore.Identity;
using makeITeasy.PerformanceReview.BusinessCore.Queries.EmployeeQueries;
using makeITeasy.PerformanceReview.Models;
using Microsoft.AspNetCore.Components.Authorization;
using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Extensions;
using makeITeasy.AppFramework.Core.Commands;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components
{
    public partial class EmployeeAssignment
    {
        public class UserViewModel : AppFramework.Core.Interfaces.IMapFrom<AppUser>
        {
            public string? Id { get; set; }

            public string? Email { get; set; }

            [Required]
            public string? Name { get; set; }
        }

        [Inject]
        private UserManager<AppUser>? _userManager { get; set; }
        [Inject]
        private AutoMapper.IMapper? _mapper { get; set; }
        [Inject]
        private MediatR.IMediator? _mediator { get; set; }
        [Inject]
        private ISnackbar? Snackbar { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationStateTask { get; set; }
        [CascadingParameter] 
        private MudDialogInstance? MudDialog { get; set; }

        private MudTable<UserViewModel>? table;
        private string? searchString = null;

        private async Task OnSearch(string text)
        {
            searchString = text;
            await table.ReloadServerData();
        }

        private async Task<TableData<UserViewModel>> ServerReload(TableState state)
        {
            if (!string.IsNullOrWhiteSpace(searchString) && _userManager != null)
            {
                var users = _userManager.Users.Where(x => x.Email.StartsWith(searchString) && x.ManagerId == null).ToList();

                return new TableData<UserViewModel>() { Items = _mapper?.Map<List<UserViewModel>>(users.Take(state.PageSize).Skip(state.Page * state.PageSize)), TotalItems = users.Count };
            }

            return new TableData<UserViewModel>() { Items = new List<UserViewModel>(), TotalItems = 0 };
        }

        private async Task OnValidSubmit(EditContext context)
        {
            if (context.Model is UserViewModel assigningUser && _userManager != null)
            {
                string? currentUserId = (await authenticationStateTask).User.GetIdentityUserID();
                AppUser? selectedUser = _userManager.Users.FirstOrDefault(x => x.Id == assigningUser.Id);

                if (selectedUser != null)
                {
                    selectedUser.ManagerId = currentUserId;
                    await _userManager.UpdateAsync(selectedUser);

                    Employee employee = new Employee() { ManagerIdentityId = currentUserId, UserIdentityId = assigningUser.Id };
                    var dbCreationResult = await _mediator.Send(new CreateEntityCommand<Employee>(employee));

                    if (dbCreationResult.Result == CommandState.Success)
                    {
                        Snackbar?.Add($"Employee assigned", Severity.Success);
                    }
                    else
                    {
                        Snackbar?.Add($"an error has occured", Severity.Error);
                    }
                }

                MudDialog?.Close(DialogResult.Ok(true));
            }

            StateHasChanged();
        }
    }
}