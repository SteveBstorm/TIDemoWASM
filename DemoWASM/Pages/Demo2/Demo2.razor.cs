namespace DemoWASM.Pages.Demo2
{
    public partial class Demo2
    {
        public Demo2()
        {
            Console.WriteLine("Constructeur");
        }

        protected override void OnInitialized()
        {
            Console.WriteLine("On Init");
        }

        protected async override Task OnInitializedAsync()
        {
            await Console.Out.WriteLineAsync("async");
        }

        public int Value { get; set; }
        public int Value2 { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {
                Console.WriteLine("first render");
                Value2 = 50;
            }
            else Value2 = Value * 2;
        }

        protected override bool ShouldRender()
        {
            return Value >= 5;
        }

        private void Increment()
        {
            ++Value;
        }

        private void ReceiveValue(int x)
        {
            Value = x;
        }
    }
}
