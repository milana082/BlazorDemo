using BlazorApp1.Data;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<BrandServices>();
builder.Services.AddSingleton<EmailService>();
builder.Services.AddHttpClient<IBrandServices,BrandServices>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5129/");
});
builder.Services.AddHttpClient<INewOpenApiServices, NewOpenApiServices>(client =>
{
    client.BaseAddress = new Uri("https://chroniclingamerica.loc.gov/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
