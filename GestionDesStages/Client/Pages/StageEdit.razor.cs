using GestionDesStages.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace GestionDesStages.Client.Pages
{
    public partial class StageEdit
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }

        public Stage Stage { get; set; } = new Stage();



        protected async Task HandleValidSubmit()
        {
        }

        protected void HandleInvalidSubmit()
        {
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
