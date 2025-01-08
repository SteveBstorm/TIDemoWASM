
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using System.Security.Claims;

namespace DemoWASM.Pages.SignalRChat
{
    public partial class Chat
    {
        public string Message { get; set; }
        public string Author { get; set; }
        public List<Message> MessageList { get; set; } = new List<Message>();

        public HubConnection Connection { get; set; }

        [Inject]
        public AuthenticationStateProvider stateProvider { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var state = await stateProvider.GetAuthenticationStateAsync();
            Author = state.User.Claims.First(x => x.Type == ClaimTypes.Email).Value;

            Connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:7049/chathub").Build();

            await Connection.StartAsync();

            Connection.On("notifyNewMessage", (Message message) => 
            {
                MessageList.Add(message);
                StateHasChanged();
            });
        }

        public async Task SendMessage()
        {
            await Connection.SendAsync("NewMessage", 
                new Message { Content = Message, Author = Author, SendDate = DateTime.Now });
        }

        public async Task JoinGroup(string groupname)
        {
            await Connection.SendAsync("JoinGroup", groupname);
            Connection.On("notifyMessageGroup_"+ groupname, (Message m) =>
            {
                MessageList.Add(m);
                StateHasChanged();
            });
        }

        public async Task SendToGroup(string groupname)
        {
            await Connection.SendAsync("SendToGroup", groupname,
                new Message { Content = Message, Author = Author, SendDate = DateTime.Now });
        }
    }
}
