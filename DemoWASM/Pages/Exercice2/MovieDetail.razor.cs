using DemoWASM.Pages.Exercice2.Models;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Exercice2
{
    public partial class MovieDetail
    {
        [Parameter]
        public Movie CurrentMovie { get; set; }
    }
}
