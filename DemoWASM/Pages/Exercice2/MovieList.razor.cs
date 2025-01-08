using DemoWASM.Pages.Exercice2.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoWASM.Pages.Exercice2
{
    public partial class MovieList
    {
        [Inject]
        public IJSRuntime JS { get; set; }
        public List<Movie> Movies { get; set; }
        //[Inject]
        public HttpClient Client { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Movies = new List<Movie>();
            await LoadData();
        }

        private async Task LoadData()
        {
            //Raccourci => Methode d'extension sur HttpClient
            //Movies = await Client.GetFromJsonAsync<List<Movie>>("movie");

            //Version papy fait de la résistance
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7049/api/");
            using(HttpResponseMessage message = await Client.GetAsync("movie"))
            {
                if (message.StatusCode == HttpStatusCode.OK)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(json);
                    Movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    StateHasChanged();
                }
                else Movies = new List<Movie>();
            }

        }

        //protected override void OnInitialized()
        //{
        //    Movies = new List<Movie> {new Movie
        //    {
        //        Id = 1,
        //        Titre = "Star Wars : A New Hope",
        //        Realisateur = "George Lucas",
        //        AnneeSortie = 1977,
        //        Genre = "Space-opera",
        //        Synopsis = "Un pirate et un wookie coursent la princesse pour ..."
        //    } };
        //}

        public async Task Add(Movie movie)
        {
            movie.Id = Movies.Max(x => x.Id) + 1;
            //await Client.PostAsJsonAsync("movie", movie);
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7049/api/");
            string json = JsonConvert.SerializeObject(movie);

            HttpContent content = new StringContent(
                json , Encoding.UTF8, "application/json");

            //string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");

            //Client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            using(HttpResponseMessage response = await Client.PostAsync("movie",content))
            {
                if(response.IsSuccessStatusCode)
                {
                    await LoadData();
                }
            }

            await LoadData();
            //Movies.Add(movie);
        }
        public async Task Remove(int id)
        {
            await Client.DeleteAsync($"movie/{id}");
            SelectedId = 0;
            await LoadData();
        }
        //public void Remove(int id)
        //{
        //    Movies.Remove(Movies.First(x => x.Id == id));
        //}   
        public Movie SelectedMovie { get; set; }
        //public void SelectMovie(int id)
        //{
        //    SelectedMovie = Movies.FirstOrDefault(x => x.Id == id);
        //}

        public int SelectedId { get; set; }
        public void SelectId(int id)
        {
            SelectedId = id;
        }


    }
}
