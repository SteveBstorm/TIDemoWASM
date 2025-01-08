using DemoWASM.Pages.Exercice2.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace DemoWASM.Pages.Exercice2
{
    public partial class MovieDetail
    {
        //[Parameter]
        public Movie CurrentMovie { get; set; }

        [Parameter]
        public int CurrentId { get; set; }
        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        public IHttpClientFactory HttpFactory { get; set; }

        protected async override Task OnParametersSetAsync()
        {
            CurrentMovie = new Movie();
            HttpClient pokeClient = HttpFactory.CreateClient("pokeapi");
            var o = await pokeClient.GetFromJsonAsync<object>("pokemon/"+CurrentId);
            await Console.Out.WriteLineAsync(JsonSerializer.Serialize(o));

            CurrentMovie = await Client.GetFromJsonAsync<Movie>($"movie/{CurrentId}");
        }
    }
}
