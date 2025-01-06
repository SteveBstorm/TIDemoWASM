using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Exercice1
{
    public partial class Quizz
    {
        public List<string> Questions { get; set; } = new List<string>();
        public int Compteur { get; set; } = 0;

        [Parameter]
        public EventCallback<string> NotifyResponse { get; set; }
        [Parameter]
        public EventCallback NotifyEndGame { get; set; }

        [Parameter]
        public string Pseudo { get; set; }

        protected override void OnInitialized()
        {
            Questions.Add("Question 1");
            Questions.Add("Question 2");
            Questions.Add("Question 3");
        }

        public void Repondre(string rep)
        {
            NotifyResponse.InvokeAsync(rep);
            Compteur++;
            if(Compteur >= Questions.Count)
            {
                NotifyEndGame.InvokeAsync();
            }
        }
    }
}
