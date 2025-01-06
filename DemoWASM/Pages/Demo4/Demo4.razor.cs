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

        [Inject]
        public HttpClient Client { get; set; }

        public string ValueFromStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon");
            var json = await client.GetFromJsonAsync<object>("");
            await Console.Out.WriteLineAsync( json.ToString());

            await JS.InvokeVoidAsync("localStorage.setItem", "valeur", "coucou");
        }

        public async Task GetValue()
        {
            ValueFromStorage = await JS.InvokeAsync<string>("localStorage.getItem", "valeur");
        }


    }
}
