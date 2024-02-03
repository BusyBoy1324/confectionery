using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using confectionery_front.Services.BiscuitServices;
using Radzen;
using confectionery_front.Services.HttpServices;
using Blazored.Modal;
using confectionery_front.Services.CookieServices;
using confectionery_front.Services.UserServices;
using confectionery_front.Services.FillingServices;
using confectionery_front.Services.OrderServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DialogService>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

builder.Services.AddScoped<IBiscuitService, BiscuitService>();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<ICookieService, CookieService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFillingService, FillingService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddBlazoredModal();
builder.Services.AddHttpContextAccessor();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddHttpClient("client", c =>
{
    c.BaseAddress = new Uri(configuration.GetValue<string>("RestIg"));
});

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
