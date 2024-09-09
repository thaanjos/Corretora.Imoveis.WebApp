using Corretora.Imoveis.Core.Authorization;
using Corretora.Imoveis.Core.Services;
using Corretora.Imoveis.WebApp.Configuration;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddConnection(builder.Configuration);
builder.Services.AddRepositorys();
builder.Services.AddServices();
builder.Services.AddApplications();


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddIdentityCore<Usuario>(options => { });
builder.Services.AddScoped<IUserStore<Usuario>, UsuarioStore>();



builder.Services.AddAuthentication("cookies")
    .AddCookie("cookies", options =>
    options.LoginPath = "/Home/Login"
    );

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
