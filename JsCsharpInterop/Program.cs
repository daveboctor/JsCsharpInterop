// https://learn.microsoft.com/en-us/aspnet/core/blazor/components/integration?view=aspnetcore-8.0#use-non-routable-components-in-pages-or-views
using JsCsharpInterop.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<JsCsharpInterop.FormaterService>();

// https://learn.microsoft.com/en-us/aspnet/core/blazor/components/integration?view=aspnetcore-8.0#use-non-routable-components-in-pages-or-views
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// https://learn.microsoft.com/en-us/aspnet/core/blazor/components/integration?view=aspnetcore-8.0#use-non-routable-components-in-pages-or-views
app.UseAntiforgery();

app.MapRazorPages();

// https://learn.microsoft.com/en-us/aspnet/core/blazor/components/integration?view=aspnetcore-8.0#use-non-routable-components-in-pages-or-views
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add 'endpoints.MapControllers()' to enable Web APIs
app.MapControllers();

app.Run();
