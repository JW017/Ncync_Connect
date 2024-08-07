using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using NCL.Components;
using NCL.Components.Layout;
using NCL.Data;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Components.Authorization;
using NCL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;





var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAD"));

builder.Services.AddScoped<AuthenticationStateProvider, IdentityValidationProvider<IdentityUser>>();


builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("superusers", policy =>
    {
        _ = policy.RequireAssertion(context => context.User.HasClaim(c =>
        {
            return c.Type == "groups" && c.Value.Contains(builder.Configuration["groups:superusersid"]);
        }));
    });

    //options.AddPolicy("normalusers", policy =>
    //{
    //    _ = policy.RequireAssertion(context => context.User.HasClaim(c =>
    //    {
    //        return c.Type == "groups" && c.Value.Contains(builder.Configuration["groups:normalusersid"]);
    //    }));
    //});

});

builder.Services.AddRazorPages().AddMicrosoftIdentityUI();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder .Services.AddControllers();

builder.Services.AddHttpClient();

//add by Justin
builder.Services.AddBlazorBootstrap();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRewriter(
    new RewriteOptions().Add(
        context => {
            if (context.HttpContext.Request.Path == "/MicrosoftIdentity/Account/SignedOut")
            { context.HttpContext.Response.Redirect("/"); }
            if (context.HttpContext.Request.Path == "/MicrosoftIdentity/Account/AccessDenied")
            { context.HttpContext.Response.Redirect("/"); }
        })
);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();



app.MapRazorPages();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(NCL.Client._Imports).Assembly);


app.MapPost("/upload", async ([FromForm] WebAssemblyTicket ticket,
    [FromServices] IWebHostEnvironment env) =>
{
foreach (var file in ticket.Attachments)
{
// Save locally
string safeFileName = WebUtility.HtmlEncode(file.FileName);
var path = Path.Combine(env.ContentRootPath, "images", safeFileName);
await using FileStream fs = new(path, FileMode.Create);
await file.CopyToAsync(fs);

// TODO: Save title, description, image reference to a database
}
}).DisableAntiforgery();

app.Run();

class WebAssemblyTicket
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFileCollection Attachments { get; set; }
}
