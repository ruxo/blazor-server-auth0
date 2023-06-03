using Auth0.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// important
builder.Services.AddAuth0WebAppAuthentication(opts => {
    opts.Domain = builder.Configuration["Auth0:Domain"]!;
    opts.ClientId = builder.Configuration["Auth0:ClientId"]!;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();