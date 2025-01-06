namespace DemoWASM.Pages.Demo3
{
    public partial class Demo3
    {
        public List<string> Liste { get; set; }

        protected override void OnInitialized()
        {
            Liste = new List<string>();
            for(int i = 0; i < 100; i++)
            {
                Liste.Add(Guid.NewGuid().ToString());
            }
        }
    }
}
