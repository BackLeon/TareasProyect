using Front.Modelos;

namespace Front.Services.IServices
{
    public interface IServicioAutenticacion
    {
        Task<RespuestaAutenticacion> Acceder(UsuarioAutenticacion usuarioDesdeAutenticacion);
        Task<RespuestaRegistro> RegistrarUsuario(UsuarioRegistro usuarioParaRegistro);

        Task Salir();

    }
}
