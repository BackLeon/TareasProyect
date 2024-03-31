using Front.Services.IServices;
using Microsoft.AspNetCore.Components;

namespace Front.Pages.autenticacion
{
    public partial class Salir
    {
        [Inject]
        public IServicioAutenticacion? servicioAutenticacion { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await servicioAutenticacion!.Salir();
            NavigationManager!.NavigateTo("/Acceder");
        }
    }
}
