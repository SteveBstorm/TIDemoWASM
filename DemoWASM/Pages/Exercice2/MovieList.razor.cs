using DemoWASM.Pages.Exercice2.Models;

namespace DemoWASM.Pages.Exercice2
{
    public partial class MovieList
    {
        public List<Movie> Movies { get; set; }

        protected override void OnInitialized()
        {
            Movies = new List<Movie> {new Movie
            {
                Id = 1,
                Titre = "Star Wars : A New Hope",
                Realisateur = "George Lucas",
                AnneeSortie = 1977,
                Genre = "Space-opera",
                Synopsis = "Un pirate et un wookie coursent la princesse pour ..."
            } };
        }

        public void Add(Movie movie)
        {
            movie.Id = Movies.Max(x => x.Id) + 1; 
            Movies.Add(movie);
        }

        public void Remove(int id)
        {
            Movies.Remove(Movies.First(x => x.Id == id));
        }   
        public Movie SelectedMovie { get; set; }
        public void SelectMovie(int id)
        {
            SelectedMovie = Movies.FirstOrDefault(x => x.Id == id);
        }


    }
}
