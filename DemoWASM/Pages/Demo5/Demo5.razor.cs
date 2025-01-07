using System.Text.Json;

namespace DemoWASM.Pages.Demo5
{
    public partial class Demo5
    {
        public JeuVideo MyForm { get; set; } = new JeuVideo();

        public void SubmitForm()
        {
            Console.WriteLine(JsonSerializer.Serialize(MyForm));
        }

        public List<string> Genres { get; set; } = new List<string>
        {
            "Action", "RPG", "Meuporg", "Combat", "RTS", "MOBA"
        };

    }
}
