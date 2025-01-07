using System.ComponentModel.DataAnnotations;

namespace DemoWASM.Pages.Demo5
{
    public class JeuVideo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1970, 2030)]
        public int ReleaseYear { get; set; }

        public string Genre { get; set; }
    }
}
