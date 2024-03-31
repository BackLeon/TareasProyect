global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Blazored.Toast;

using Front;
using Front.Services;
using Front.Services.IServices;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IServicioAutenticacion, ServicioAutenticacion>();
//Para usar el Local Storage del navegador
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

//builder.Services.AddScoped<AuthStateProvider>();
//builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<AuthStateProvider>());
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
//Agregar para la autenticación y autorización
builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
