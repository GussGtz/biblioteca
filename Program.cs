using BibliotecaSánchezLobatoGael83.Context;
using BibliotecaSánchezLobatoGael83.Services.IServices;
using BibliotecaSánchezLobatoGael83.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

//Las inyecciones de dependencias
builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();
builder.Services.AddTransient<IRolServices, RolServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Rutas personalizadas que se utilizan para ir la index de los diversos CRUD
app.MapControllerRoute(
    name: "roles",
    pattern: "roles/{action=Index}/{id?}",
    defaults: new { controller = "Roles" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
