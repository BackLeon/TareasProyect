using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Front.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Front.Services
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        //private readonly IJSRuntime _jsRuntime;
        //public AuthStateProvider(IJSRuntime jsRuntime)
        //{
        //    _jsRuntime = jsRuntime;

        //}
        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1YnJpLXBjQGV4YW1wbGUuY29tIiwicm9sZSI6IkFETUlOIiwibmJmIjoxNzA5OTA5NDkwLCJleHAiOjE3MTA1MTQyOTAsImlhdCI6MTcwOTkwOTQ5MCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MTc4In0.JH_2TRszGj1cy60ITIhYfznsDf9vtrzZ3jEzYyvaCvJ6hxifIr27X9nEuL2i6B7o1PhNJRFptlat1O-vC75GCg";
        //    var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");
        //    var user = new ClaimsPrincipal(identity);
        //    await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "Token");
        //    var state = new AuthenticationState(user);
        //    NotifyAuthenticationStateChanged(Task.FromResult(state));

        //    return state;
        //}

        private readonly HttpClient _cliente;
        private readonly ILocalStorageService _localStorageService;
        private readonly IJSRuntime _jsRuntime;

        public AuthStateProvider(IJSRuntime jsRuntime, ILocalStorageService localStorageService, HttpClient cliente)
        {
            _jsRuntime = jsRuntime;
            _localStorageService = localStorageService;
            _cliente = cliente;
        }

        //public AuthStateProvider(HttpClient cliente, ILocalStorageService localStorageService)
        //{
        //    _cliente = cliente;
        //    _localStorageService = localStorageService;
        //}
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InBlcGUtcGNAZXhhbXBsZS5jb20iLCJ1bmlxdWVfbmFtZSI6IlBlcGUiLCJyb2xlIjoiQURNSU4iLCJuYmYiOjE3MDk4NTE3MjIsImV4cCI6MTcxMDQ1NjUyMiwiaWF0IjoxNzA5ODUxNzIyLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAifQ.DQsxeNzI-Q-TBfAmClopc_Ub23no9w6WF9uhsXlbSuGJYWYo4TN_kyILeNZTilFXCxdvfyzD4UwLtY3eii7fmw";
            //string token = await _jsRuntime.InvokeAsync<string>("localstorage.getItem", "Token");
            var token = await _localStorageService.GetItemAsync<string>("Token");
            //var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token!), "jwt");
            if (token == null)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            //var user = new ClaimsPrincipal(identity);

            //var state = new AuthenticationState(user);
            _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            //NotifyAuthenticationStateChanged(Task.FromResult(state));

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
        }
        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    var token = await _localStorageService.GetItemAsync<string>(Inicializar.Token_Local);
        //    if (token == null)
        //    {
        //        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        //    }
        //    _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        //    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
        //}

        public void NotificarUsuarioLogueado(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotificarUsuarioSalir()
        {
            var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            NotifyAuthenticationStateChanged(authState);
        }

    }
}