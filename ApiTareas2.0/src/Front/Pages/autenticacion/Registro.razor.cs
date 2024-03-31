using Front.Modelos;
using Front.Services.IServices;
using Microsoft.AspNetCore.Components;

namespace Front.Pages.autenticacion
{
    public partial class Registro
    {
        //private UsuarioRegistro UsuarioParaRegistro = new UsuarioRegistro();
        //public bool EstaProcesando { get; set; } = false;
        //public bool MostrarErroresRegistro {  get; set; }

        //public string? Errores { get; set; }

        //[Inject]
        //public IServicioAutenticacion? servicioAutenticacion { get; set; }

        //[Inject]
        //public NavigationManager? navigationManager { get; set; }

        //private async Task RegistrarUsuario()
        //{
        //    MostrarErroresRegistro = false;
        //    EstaProcesando = true;
        //    var result = await servicioAutenticacion!.RegistrarUsuario(UsuarioParaRegistro);
        //    if (result.registroCorrecto)
        //    {
        //        EstaProcesando = false;
        //        navigationManager!.NavigateTo("/Acceder");
        //    }
        //    else
        //    {
        //        EstaProcesando = false;
        //        Errores = result.Errores;
        //        MostrarErroresRegistro = true;
        //    }
        //}
    }
}
