
using _01_Framework.Application;
using _01_Framework.Application.Convertors;
using _01_Framework.Infrastructure.ExtensionMethods;
using _01_Framework.Application.Email;
using Microsoft.AspNetCore.Authentication.Cookies;
using UserManagement.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
Bootstrapper.Config(builder.Services, builder.Configuration.GetConnectionString("DigikalaConnection"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IViewRenderService,RenderViewToString>();
builder.Services.AddScoped<IAuthenticationHelper,AuthenticationHelper>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/RegisterAndLogin";
        options.LogoutPath = "/Logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(14);
    });
builder.Services.AddSession(options =>
    options.IdleTimeout=TimeSpan.FromHours(1)
);

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

app.UseSession();

app.MapRazorPages();

app.Run();
