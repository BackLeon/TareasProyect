using Front.Modelos;
using Front.Services.IServices;
using Microsoft.AspNetCore.Components;
using System.Web;

namespace Front.Pages.autenticacion
{
    public partial class Acceder
    {
        //private UsuarioAutenticacion usuarioAutenticacion = new UsuarioAutenticacion();
        //public bool EstaProcesando { get; set; } = false;
        //public bool MostrarErroresAutenticacion { get; set; } = false;

        //public string? UrlRetorno { get; set; }

        //public string? Errores { get; set; }

        //[Inject]
        //public IServicioAutenticacion? servicioAutenticacion { get; set; }

        //[Inject]
        //public NavigationManager? navigationManager { get; set; }

        //private async Task AccesoUsuario()
        //{
        //    MostrarErroresAutenticacion = false;
        //    EstaProcesando = true;
        //    var result = await servicioAutenticacion!.Acceder(usuarioAutenticacion);
        //    if (result.IsSuccess)
        //    {
        //        EstaProcesando = false;
        //        var urlAbsoluta = new Uri(navigationManager!.Uri);
        //        var parametrosQuery = HttpUtility.ParseQueryString(urlAbsoluta.Query);
        //        UrlRetorno = parametrosQuery["returnUrl"];
        //        if (string.IsNullOrEmpty(UrlRetorno))
        //        {
        //            navigationManager.NavigateTo("/");
        //        }
        //        else
        //        {
        //            navigationManager.NavigateTo("/" + UrlRetorno);
        //        }

        //    }
        //    else
        //    {
        //        EstaProcesando = false;
        //        MostrarErroresAutenticacion = true;
        //        Errores = "Email, licencia y/o contraseña son incorrectos";
        //        navigationManager!.NavigateTo("/acceder");
        //    }
        //}
    }
}
