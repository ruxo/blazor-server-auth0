using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blazor.Example.Pages;

[Authorize]
public class Logout : PageModel
{
    public async Task OnGet() {
        var props = new LogoutAuthenticationPropertiesBuilder().WithRedirectUri("/").Build();

        await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, props);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}