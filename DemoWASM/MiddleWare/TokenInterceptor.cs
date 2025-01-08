using Microsoft.JSInterop;

namespace DemoWASM.MiddleWare
{
    public class TokenInterceptor(IJSRuntime JS): DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            if(!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("Authorization", "bearer " + token);
            }
            //HttpResponseMessage m =  await base.SendAsync(request, cancellationToken);
            //if(!m.IsSuccessStatusCode)
            //{
            //    switch (m.StatusCode)
            //    {
            //        case System.Net.HttpStatusCode.Unauthorized:
            //            throw new HttpRequestException();
            //            break;
            //    }
            //}
            //return await Task.FromResult(m);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
