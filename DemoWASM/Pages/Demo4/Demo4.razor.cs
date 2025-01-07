using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text.Json;

namespace DemoWASM.Pages.Demo4
{
    public partial class Demo4
    {
        [Inject]
        public IJSRuntime JS { get; set; }
        public IJSObjectReference JSObject { get; set; }

        public string ValueFromStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            string s = "General Kenobi";
            JSObject = await JS.InvokeAsync<IJSObjectReference>("import", "./scripts/monscript.js");
            await JSObject.InvokeVoidAsync("MaSuperFonction", s);
            await JS.InvokeVoidAsync("localStorage.setItem", "valeur", "coucou");
        }

        public async Task GetValue()
        {
            ValueFromStorage = await JS.InvokeAsync<string>("localStorage.getItem", "valeur");
        }


    }
}
