using CurrieTechnologies.Razor.SweetAlert2;
using DAL.Conn;
using DAL.Repo;
using eTakaf2025.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server;
using SAL;

var builder = WebApplication.CreateBuilder(args);

var prodConnStr = builder.Configuration.GetConnectionString("PROD") ?? "";
var SPMBConnStr = builder.Configuration.GetConnectionString("SPMB") ?? "";
builder.Services.AddScoped<ServerProd>(conn => new ServerProd(prodConnStr));
builder.Services.AddScoped<Server130>(conn => new Server130(SPMBConnStr));

builder.Services.AddSweetAlert2(options =>
{
    options.Theme = SweetAlertTheme.Default;
});

//builder.Services.AddScoped<IServices, Services>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "eTakaf";
        opt.LoginPath = "/SessiTamat";
        opt.LogoutPath = "/logout";
        opt.AccessDeniedPath = "/AccessDenied";
        opt.Cookie.MaxAge = TimeSpan.FromMinutes(15);
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<CircuitOptions>(options => options.DetailedErrors = true);

builder.Services.AddScoped<IServices,Services>();
builder.Services.AddScoped<IMasterRepo, MasterRepo>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.MapStaticAssets();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
