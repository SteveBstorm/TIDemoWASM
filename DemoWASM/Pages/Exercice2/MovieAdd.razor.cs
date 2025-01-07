using DemoWASM.Pages.Exercice2.Models;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Exercice2
{
    public partial class MovieAdd
    {
        public Movie MovieForm { get; set; } = new Movie();

        private List<string> Categories = new List<string>
        {
            "Horreur", "Drame", "Comédie", "Space-opera", "..."
        };

        [Parameter]
        public EventCallback<Movie> NotifyNewMovie { get; set; }

        public void FormSubmit()
        {
            NotifyNewMovie.InvokeAsync(MovieForm);
            MovieForm = new Movie();
        }
    }
}
