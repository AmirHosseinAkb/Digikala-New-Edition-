
using _01_Framework.Infrastructure.ExtensionMethods;
using Microsoft.AspNetCore.Authentication.Cookies;
using UserManagement.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
Bootstrapper.Config(builder.Services, builder.Configuration.GetConnectionString("DigikalaConnection"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/RegisterAndLogin";
        options.LogoutPath = "/Logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(14);
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

app.UseCultureCookie();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
