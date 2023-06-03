using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blazor.Example.Pages;

public class Login : PageModel
{
    public async Task OnGet(string? redirectUri) {
        var props = new LoginAuthenticationPropertiesBuilder()
                   .WithRedirectUri(redirectUri ?? "/")
                   .Build();
        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, props);
    }
}