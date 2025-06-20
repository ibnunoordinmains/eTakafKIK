using CurrieTechnologies.Razor.SweetAlert2;
using DAL.Conn;
using DAL.Repo;
using eTakaf2025.Components;
using IdentityAuthentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server;
using SAL;

var builder = WebApplication.CreateBuilder(args);

var prodConnStr = builder.Configuration.GetConnectionString("PROD") ?? "";
var SPMBConnStr = builder.Configuration.GetConnectionString("SPMB") ?? "";
var EHRConnStr = builder.Configuration.GetConnectionString("EHR") ?? "";

builder.Services.AddScoped<ServerProd>(conn => new ServerProd(prodConnStr));
builder.Services.AddScoped<Server130>(conn => new Server130(SPMBConnStr));
builder.Services.AddScoped<ServerEHR>(conn => new ServerEHR(EHRConnStr));

builder.Services.AddSweetAlert2(options =>
{
    options.Theme = SweetAlertTheme.Default;
});

//builder.Services.AddScoped<IServices, Services>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "e-takaf";
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
builder.Services.AddScoped<IIdentityAuthenticationLib, IdentityAuthenticationLib>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();
app.UsePathBase("/e-takaf/");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
