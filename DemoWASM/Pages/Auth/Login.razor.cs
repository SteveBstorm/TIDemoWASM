using DemoWASM.Pages.Auth.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace DemoWASM.Pages.Auth
{
    public partial class Login
    {
        public LoginForm Form { get; set; } = new LoginForm();

        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }

        [Inject]
        public AuthenticationStateProvider StateProvider { get; set; }

        public async Task SubmitLogin()
        {
            HttpResponseMessage message = await Client.PostAsJsonAsync("auth/login", Form);
            if(!message.IsSuccessStatusCode)
            {
                await Console.Out.WriteLineAsync("Erreur de login : "+ message.ReasonPhrase);
            }
            string token = await message.Content.ReadAsStringAsync();
            await JS.InvokeVoidAsync("localStorage.setItem", "token", token);

            ((MyAuthState)StateProvider).NotifyUserChange();
        }
    }
}
