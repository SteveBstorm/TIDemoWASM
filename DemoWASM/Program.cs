using DemoWASM;
using DemoWASM.MiddleWare;
using DemoWASM.Pages.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<TokenInterceptor>();

builder.Services.AddHttpClient("default", sp =>
{
    new HttpClient();
    sp.BaseAddress = new Uri("https://localhost:7049/api/");
}).AddHttpMessageHandler<TokenInterceptor>();

builder.Services.AddHttpClient("pokeapi", sp =>
{
    new HttpClient();
    sp.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
});

builder.Services.AddScoped<HttpClient>(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("default"));

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7049/api/") });

builder.Services.AddAuthorizationCore();
//obligatoirement en singleton dans webassembly
builder.Services.AddSingleton<AuthenticationStateProvider, MyAuthState>();

await builder.Build().RunAsync();
