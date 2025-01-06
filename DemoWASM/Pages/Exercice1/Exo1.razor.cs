namespace DemoWASM.Pages.Exercice1
{
    public partial class Exo1
    {
        public string Username { get; set; }

        private List<string> Reponses { get; set; } = new List<string>();
        public bool GameIsOver { get; set; }

        public void EnregistrerReponse(string reponse)
        {
            Reponses.Add(reponse);
        }

        private void ChangeGameStatus()
        {
            GameIsOver = true;
        }

    }
}
