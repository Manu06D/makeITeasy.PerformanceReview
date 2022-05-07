using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
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

            public void Mapping(AutoMapper.Profile profile)
            {
                if (profile != null)
                {
                    profile.CreateMap<AppUser, UserViewModel>().ForMember(d => d.Role, opt => opt.MapFrom(new CustomResolver()));
                }
            }

            public class CustomResolver : AutoMapper.IValueResolver<AppUser, UserViewModel, String>
            {
                string IValueResolver<AppUser, UserViewModel, string>.Resolve(AppUser source, UserViewModel destination, string destMember, ResolutionContext context)
                {
                    string result = string.Empty;
                    var _userManager = (UserManager<AppUser>)context.Options.Items["RoleManager"];
                    if (_userManager != null)
                    {
                        IList<string> roles = Task.Run(async () => await _userManager.GetRolesAsync(source)).Result;
                        result = string.Join(",", roles);
                    }

                    return result;
                }
            }
        }

        private MudTable<UserViewModel>? table;
        private string? searchString = null;
        private UserViewModel? elementBeforeEdit;
        private IList<IdentityRole>? dbRoles;

        [Inject]
        private UserManager<AppUser>? _userManager { get; set; }
        [Inject]
        private RoleManager<IdentityRole>? _roleManager { get; set; }

        [Inject]
        private IMapper? _mapper { get; set; }

        [Inject]
        ISnackbar? Snackbar { get; set; }

        [Inject]
        private IDialogService? DialogService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            dbRoles = _roleManager?.Roles.ToList();
        }

        private async Task OnSearch(string text)
        {
            searchString = text;
            await table.ReloadServerData();
        }

        private async Task<TableData<UserViewModel>> ServerReload(TableState state)
        {
            var users = _userManager?.Users;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                users = users?.Where(x => x.Email.StartsWith(searchString));
            }

            return new TableData<UserViewModel>() {
                Items = _mapper?.Map<List<UserViewModel>>(users?.ToList().Take(state.PageSize).Skip(state.Page * state.PageSize), opt => opt.Items["RoleManager"] = _userManager)
            };
        }

        private void BackupItem(object element)
        {
            if(element is UserViewModel user)
            {
                elementBeforeEdit = new()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role,
                };
            }
        }
        private void ResetItemToOriginalValues(object element)
        {
            if (element is UserViewModel user)
            {
                user.Id = elementBeforeEdit?.Id;
                user.Email = elementBeforeEdit?.Email;
                user.Role = elementBeforeEdit?.Role;
            }
        }

        private void ItemHasBeenCommitted(object element)
        {
            Task.Run(async () => await ItemHasBeenCommittedAsync(element));
        }

        private async Task ItemHasBeenCommittedAsync(object element)
        {
            if (element is UserViewModel newUser)
            {
                if (newUser.Role != elementBeforeEdit?.Role && _userManager != null)
                {
                    var user = await _userManager.FindByIdAsync(elementBeforeEdit?.Id ?? string.Empty);
                    if (user != null)
                    {
                        if (!string.IsNullOrEmpty(elementBeforeEdit?.Role))
                        {
                            await _userManager.RemoveFromRoleAsync(user, elementBeforeEdit?.Role ?? String.Empty);
                        }
                        await _userManager.AddToRoleAsync(user, newUser.Role);
                    }
                }
            }
        }

        private async Task CreateNewAsync()
        {
            var dialog = 
                DialogService?.Show<CreateEditUser>(
                    "Creating/Editing new Review", 
                    new DialogParameters() {["id"] = 0}, 
                    new DialogOptions() {CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true, DisableBackdropClick = false});

            DialogResult? result = await dialog.Result;

            if (!result.Cancelled)
            {
                int.TryParse(result.Data.ToString(), out int createdReview);
                Snackbar?.Add($"Review Created (id:{createdReview})", Severity.Success);
                await table.ReloadServerData();
            }
        }
    }
}