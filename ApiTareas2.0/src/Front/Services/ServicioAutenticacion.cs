using Blazored.LocalStorage;
using Front.Helpers;
using Front.Modelos;
using Front.Pages.autenticacion;
using Front.Services.IServices;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Front.Services
{
    public class ServicioAutenticacion : IServicioAutenticacion
    {
        private readonly HttpClient _cliente;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        public ServicioAutenticacion(HttpClient cliente,
            ILocalStorageService localStorage,
            AuthenticationStateProvider estadoProveedorAutenticacion)
        {
            _cliente = cliente;
            _localStorage = localStorage;
            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
        }

        public async Task<RespuestaAutenticacion> Acceder(UsuarioAutenticacion usuarioDesdeAutenticacion)
        {
            var content = JsonConvert.SerializeObject(usuarioDesdeAutenticacion);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _cliente.PostAsync($"{Inicializar.UrlBaseApi}api/Account/Login", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = (JObject)JsonConvert.DeserializeObject(contentTemp)!;

            if (response.IsSuccessStatusCode)
            {
                var Email = resultado["email"]!.Value<string>();
                var Token = resultado["token"!]!.Value<string>();
                var Roles = resultado["roles"]!.Value<string>();




                await _localStorage.SetItemAsync("Token", Token);
                await _localStorage.SetItemAsync("Email", Email);
                await _localStorage.SetItemAsync("Roles", Roles);

                ((AuthStateProvider)_estadoProveedorAutenticacion).NotificarUsuarioLogueado(Token!);
                _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);
                return new RespuestaAutenticacion { IsSuccess = true };
            }
            else
            {
                return new RespuestaAutenticacion { IsSuccess = false };
            }
        }

        public async Task<RespuestaRegistro> RegistrarUsuario(UsuarioRegistro usuarioParaRegistro)
        {
            var content = JsonConvert.SerializeObject(usuarioParaRegistro);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _cliente.PostAsync($"{Inicializar.UrlBaseApi}api/Account/register", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var js = (JObject)JsonConvert.DeserializeObject(contentTemp)!;
            //var resultado = JsonConvert.DeserializeObject<RespuestaRegistro>(contentTemp);
            var final = js["errorMessage"]!.ElementAt(0).ToString();
            if (final == "Te has registrado con exito")
            {

                return new RespuestaRegistro { registroCorrecto = true, Errores = js["errorMessage"]!.ElementAt(0).ToString() };
            }
            else
            {
                return new RespuestaRegistro { registroCorrecto = false, Errores = js["errorMessage"]!.ElementAt(0).ToString() };
            }
        }

        public async Task Salir()
        {
            await _localStorage.RemoveItemAsync("Token");
            await _localStorage.RemoveItemAsync("Email");
            await _localStorage.RemoveItemAsync("Roles");
            ((AuthStateProvider)_estadoProveedorAutenticacion).NotificarUsuarioSalir();
            _cliente.DefaultRequestHeaders.Authorization = null;
        }
    }
}
