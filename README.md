# Blazor Server with Auth0 - Abridge Version

This document is derived from the original post [Securing the application with Auth0](https://auth0.com/blog/what-is-blazor-tutorial-on-building-webapp-with-authentication/#Securing-the-Application-with-Auth0).

Latest testing conducted with .NET 7.0

**Configuration Steps**:
1. Add the Nuget package `Auth0.AspNetCore.Authentication`.
2. Invoke `AddAuth0WebAppAuthentication` during the set up of ASP.NET Core services (refer to `Program.cs`).
   * Also include `app.UseAuthentication()` and `app.UseAuthorization()`.
3. Add the namespaces `Microsoft.AspNetCore.Authorization` and `Microsoft.AspNetCore.Components.Authorization` to
   `_Imports.razor`.
4. Encapsulate `Route` component in `App.razor` with the `CascadingAuthenticaitonState` component
   (from `Microsoft.AspNetCore.Authorization`) to enable underlying components to retrieve
   the authentication state.
   * Also replace `RouteView` component to `AuthorizeRouteView` which enables the handling of both
     authorized and unauthorized states.

## Protect Blazor component 
The Blazor framework provides `AuthorizeView` component to define views for both authorized and 
unauthorized users. Refer to `Index.razor` for usage examples.

## Logging In/Out with Auth0
The example is configured for the Authorization Code Flow. Some pre-configuration needs
to be done on the Auth0 side (such as setting Redirect URIs and Logout URIs -- refer to the original 
document for guidance). Also, the authorization flow depends on server-to-server communication, thus Razor
pages are required to serve that server communication. Consult `Login.cshtml` and `Logout.cshtml`
for information on how to log in/out using Razor pages.

## Prevent Blazor's reconnection message
Since the authentication pages are Razor pages, a "reconnection" message from the Blazor
framework may briefly appear during transitions from a Blazor page to these pages. This needs to be 
manually managed. This example introduces a custom JS script, `blazor.example.js`, and a wrapper class,
`JsInterop.cs`, to assist in the suppression process. Refer to the `Index.razor` page for usage.

# Access Token
In order to obtain the access token, Auth0 mandates the use of an API Audience. This means you need to set up
an API in Auth0 and create an identity for the API's audience. Subsequently, use the `WithAccessToken` method to
specify the audience intended for the token (refer to `Program.cs`). Be aware that either a
`ClientSecret` or a Client Assertion is required to acquire the token. At least one of these must be configured.

## Retrieve the token
Given that the Auth0 library utilizes Razor pages for server-side processing, the tokens are stored in
`HttpContext`. To retrieve tokens, the extension method `GetTokenAsync` can be invoked to retrieve
either the `access_token` or `id_token`. Refer to `Index.razor` for an illustrative example.


# Additional Resources
* [Auth0 with Blazor Server using OpenIdConnect library](https://github.com/ruxo/blazor-server-oidc-auth0)
* [Auth0 (or any OIDC) with Blazor WASM standalone](https://github.com/ruxo/blazor-wasm-auth0)
* [Auth0 with Blazor Hosted solution - Abridge version](https://github.com/ruxo/blazor-hosted-auth0)