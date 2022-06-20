using Microsoft.AspNetCore.Components;
using MudBlazor;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components;
using makeITeasy.PerformanceReview.Models;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Pages
{
    public partial class Users
    {
        public class UserViewModel : AppFramework.Core.Interfaces.IMapFrom<AppUser>
        {
            public string? Id { get; set; }

            public string? Email { get; set; }

            public string? Role { get; set; }
        }

        private MudTable<UserViewModel>? table;
        private string? searchString = null;
        private UserViewModel? userBeforeEdit;
        private IList<IdentityRole>? dbRoles;

        [Inject]
        private UserManager<AppUser>? userManager { get; set; }
        [Inject]
        private RoleManager<IdentityRole>? roleManager { get; set; }
        [Inject]
        private IMapper? _mapper { get; set; }
        [Inject]
        ISnackbar? Snackbar { get; set; }
        [Inject]
        private IDialogService? DialogService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            dbRoles = roleManager?.Roles.ToList();
        }

        private async Task OnSearch(string text)
        {
            searchString = text;
            await table!.ReloadServerData();
        }

        private async Task<TableData<UserViewModel>> ServerReloadAsync(TableState state)
        {
            IQueryable<AppUser>? users = userManager?.Users;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                users = users?.Where(x => x.Email.StartsWith(searchString) || x.Name.StartsWith(searchString));
            }

            return new TableData<UserViewModel>() {Items = await AddRolesToResultAndMap(users?.Take(state.PageSize).Skip(state.Page * state.PageSize).ToList()) };
        }

        private async Task<List<UserViewModel>>? AddRolesToResultAndMap(IEnumerable<AppUser>? users)
        {
            return users.Select(x => AddRolesAndMapUser(x)).ToList();
        }

        private UserViewModel AddRolesAndMapUser(AppUser user)
        {
            UserViewModel userViewModel = _mapper?.Map<UserViewModel>(user);
            //HACK : this can't be //ized ... to be checked
            userViewModel.Role = string.Join(',', Task.Run(async () => await userManager.GetRolesAsync(user)).Result);

            return userViewModel;
        }

        private void BackupItem(object element)
        {
            if(element is UserViewModel user)
            {
                userBeforeEdit = new()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role,
                };
            }
        }

        private void ResetItemToOriginalValues(object element)
        {
            if (element is UserViewModel user && userBeforeEdit != null)
            {
                user.Id = userBeforeEdit.Id;
                user.Email = userBeforeEdit.Email;
                user.Role = userBeforeEdit.Role;
            }
        }

        private void ProcessToSaveUser(object element)
        {
            Task.Run(async () => await ProcessToSaveUserAsync(element));
        }

        private async Task ProcessToSaveUserAsync(object element)
        {
            if (element is UserViewModel newUser)
            {
                if (newUser.Role != userBeforeEdit?.Role && userManager != null)
                {
                    var user = await userManager.FindByIdAsync(userBeforeEdit?.Id ?? string.Empty);

                    if (user != null)
                    {
                        if (!string.IsNullOrEmpty(userBeforeEdit?.Role))
                        {
                            await userManager.RemoveFromRoleAsync(user, userBeforeEdit?.Role ?? string.Empty);
                        }

                        await userManager.AddToRoleAsync(user, newUser.Role);
                    }
                }
            }
        }

        private async Task CreateNewUserAsync()
        {
            var dialog = 
                DialogService?.Show<CreateEditUser>(
                    "Creating/Editing new Review", 
                    new DialogParameters() {["id"] = 0}, 
                    new DialogOptions() {CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true, DisableBackdropClick = false});

            DialogResult? result = await dialog.Result;

            if (!result.Cancelled)
            {
                _ = int.TryParse(result.Data.ToString(), out int createdReview);
                Snackbar?.Add($"Review Created (id:{createdReview})", Severity.Success);
                await table.ReloadServerData();
            }
        }
    }
}