using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DemoWASM.Pages.Auth
{
    public class MyAuthState(IJSRuntime js) : AuthenticationStateProvider
    {
        string token;
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            token = await js.InvokeAsync<string>("localStorage.getItem", "token");

            if(!string.IsNullOrEmpty(token))
            {
                JwtSecurityToken jwt = new JwtSecurityToken(token);
                ClaimsIdentity currentUserIdentity = new ClaimsIdentity(jwt.Claims, "JwtAuth");

                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(currentUserIdentity)));
            }
            ClaimsIdentity anonymous = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));

        }

        public void NotifyUserChange()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
