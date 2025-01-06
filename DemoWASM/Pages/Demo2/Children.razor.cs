using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Demo2
{
    public partial class Children
    {
        [Parameter]
        public int ValueFromParent { get; set; }

        [Parameter]
        public EventCallback<int> NotifyParent { get; set; }

        protected override void OnParametersSet()
        {
            ValueFromParent *= 5;
        }

        private void SendToParent()
        {
            NotifyParent.InvokeAsync(42);
        }
    }
}
