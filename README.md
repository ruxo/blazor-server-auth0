# Blazor Server with Auth0 abridge version

The original post is from [Securing the application with Auth0](https://auth0.com/blog/what-is-blazor-tutorial-on-building-webapp-with-authentication/#Securing-the-Application-with-Auth0).

Latest tested with .NET 7.0

**Configuration Steps**:
1. Add Nuget package `Auth0.AspNetCore.Authentication`
2. Call `AddAuth0WebAppAuthentication` during setting up ASP.NET Core services (see `Program.cs`).
   * Also add `app.UseAuthentication()` and `app.UseAuthorization()`.
3. Add namespace `Microsoft.AspNetCore.Authorization` and `Microsoft.AspNetCore.Components.Authorization` in
   `_Imports.razor`
4. Wrap `Route` component in `App.razor` with `CascadingAuthenticaitonState` component
   (from `Microsoft.AspNetCore.Authorization`) to allow underlying compoonents to retrieve
   authentication state.
   * Also change `RouteView` component to `AuthorizeRouteView` which allows handling
     authorizing state and not-authorized state.

## Protect Blazor component 
Blazor framework has `AuthorizeView` component to define views for authorized user and 
unauthorized user. See the usage in `Index.razor`.

## To Login/Logout with Auth0
Since this example is configured for Authorization Code Flow. Some pre-configuration needs
to be done on Auth0 side (setting Redirect URIs and Logout URIs -- see the original document
for guidance). Also, the authorization flow relies on server-to-server communication, so Razor
pages are needed to serve that server communication. See `Login.cshtml` and `Logout.cshtml`
about how to login/logout using Razor pages.

*Note*: This mechanism has drawback that during server transfer from Blazor page to Razor page,
Blazor page may show "server disconnected" message. I cannot yet find a way to mitigate this issue.