using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Microsoft.AspNetCore.Identity;
using makeITeasy.PerformanceReview.BlazorServerApp.Shared.Components;
using makeITeasy.PerformanceReview.BusinessCore.Queries.EmployeeQueries;
using makeITeasy.PerformanceReview.Models;
using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Extensions;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Pages
{
    public partial class Employees
    {
        [CascadingParameter]
        private Task<AuthenticationState>? authenticationStateTask { get; set; }

        [Inject]
        private IDialogService? DialogService { get; set; }

        [Inject]
        private UserManager<IdentityUser>? _userManager { get; set; }

        [Inject]
        ISnackbar? Snackbar { get; set; }

        private GenericList<Employee, EmployeeViewModel, BasicEmployeeQuery>? table;
        private BasicEmployeeQuery? defaultQuery;

        public class EmployeeViewModel : AppFramework.Core.Interfaces.IMapFrom<Employee>
        {
            public int Id { get; set; }

            public string? Name { get; set; }

            public string? Email { get; set; }

            //public DateTime? LastReviewed { get; set; }

            //public void Mapping(AutoMapper.Profile profile)
            //{
            //    if (profile != null)
            //    {
            //        profile.CreateMap<IdentityUser, EmployeeViewModel>()
            //            //.ForMember(d => d.Email, opt => opt.MapFrom(new CustomResolver()));
            //            //.ForMember(d => d.LastReviewed, opt => opt.MapFrom(src => src.I))
            //    }
            //}

            //public class CustomResolver : AutoMapper.IValueResolver<IdentityUser, EmployeeViewModel, String>
            //{
            //    string AutoMapper.IValueResolver<IdentityUser, EmployeeViewModel, string>.Resolve(IdentityUser source, EmployeeViewModel destination, string destMember, AutoMapper.ResolutionContext context)
            //    {
            //        string result = string.Empty;

            //        var _userManager = (UserManager<IdentityUser>)context.Options.Items["RoleManager"];
            //        if (_userManager != null)
            //        {
            //            var user = Task.Run(async () => await _userManager.FindByIdAsync(source.Email));
            //            result = user.Result.Email;
            //        }

            //        return result;
            //    }
            //}
        }

        protected override async Task OnInitializedAsync()
        {
            defaultQuery = new BasicEmployeeQuery() { UserManagerIdentityId = (await authenticationStateTask).User.GetIdentityUserID() };
        }

        private void Edit(int id)
        {
        }

        private void Delete(int id)
        {
        }

        private async Task CreateNewAsync()
        {
            var dialog = DialogService?.Show<EmployeeAssignment>(String.Empty,
                                                             new DialogOptions() { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true, DisableBackdropClick = false });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                int.TryParse(result.Data.ToString(), out int createdReview);
                Snackbar?.Add($"Employee assigned", Severity.Success);

                await table.ReloadTableAsync();
            }
        }
    }
}