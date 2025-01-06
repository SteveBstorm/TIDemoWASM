namespace DemoWASM.Pages
{
    public partial class Demo1
    {
        public int value { get; set; } = 42;

        public string Text { get; set; }

        private void Increment()
        {
            value += 1;
        }

        private void Add(int x)
        {
            value += x;
        }

        private void Change(string s)
        {
            Text = s;
        }
    }
}
