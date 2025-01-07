using System.ComponentModel.DataAnnotations;

namespace DemoWASM.Pages.Exercice2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        public string Realisateur { get; set; }
        [Range(1970, int.MaxValue)]
        public int AnneeSortie { get; set; }
        [MinLength(100)]
        public string Synopsis { get; set; }
        public string Genre { get; set; }
    }
}
