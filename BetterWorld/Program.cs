using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.LoginPath = "/User/Login";
        options.AccessDeniedPath = "/Home/Error";
        options.Events.OnValidatePrincipal = context =>
        {

            var accountType = context.Properties.Items["AccountType"];
            if (!string.IsNullOrEmpty(accountType))
            {
                context.Principal.AddIdentity(new ClaimsIdentity(new[] { new Claim("AccountType", accountType) }));
            }
            return Task.CompletedTask;
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("View", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var accountType = context.User.FindFirstValue("AccountType");
            return accountType == "Job Seeker" || accountType == "Recruiter";
        });
    });

    options.AddPolicy("Recruiter", policy =>
    {
        policy.RequireClaim("AccountType", "Recruiter");

    });

    options.AddPolicy("Seeker", policy =>
    {
        policy.RequireClaim("AccountType", "Job Seeker");
    });


});


var app = builder.Build();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();  // Enable authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
