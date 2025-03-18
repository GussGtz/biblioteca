using BibliotecaGustavoGtz.Context;
using BibliotecaGustavoGtz.Middleware;
using BibliotecaGustavoGtz.Services;
using BibliotecaGustavoGtz.Services.Interfaces;
using BibliotecaGustavoGtz.Services.IServices;
using BibliotecaGustavoGtz.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

//Las inyecciones de dependencias
builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();
builder.Services.AddTransient<IRolServices, RolServices>();
builder.Services.AddScoped<ITopicServices, TopicServices>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUsuarioBookService, UsuarioBookService>();

// Adicion de JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;  // Asegúrate de usar HTTPS en producción
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = "BibliotecaAPI",  // Cambia por el emisor correcto
        ValidAudience = "BibliotecaClient",  // Cambia por la audiencia correcta
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

// Configuración de políticas de autorización
builder.Services.AddAuthorization(options =>
{
    // Aquí definimos las políticas basadas en roles
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
    options.AddPolicy("Guest", policy => policy.RequireRole("Guest"));
});


// Llamada a Build() debe ser antes de configuraciones del pipeline
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");  // Manejo de excepciones en producción
    app.UseStatusCodePagesWithReExecute("/Home/NotFound");  // Manejo de errores 404
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();  // Página de errores detallada en desarrollo
}

app.UseHttpsRedirection();
app.UseRouting();

// Agregar el middleware JWT antes de la autenticación y autorización
app.UseMiddleware<JwtMiddleware>();

app.UseAuthentication();  // Añadir este para que funcione JWT
app.UseAuthorization();

app.MapStaticAssets();

// Rutas personalizadas que se utilizan para ir la index de los diversos CRUD
app.MapControllerRoute(
    name: "roles",
    pattern: "roles/{action=Index}/{id?}",
    defaults: new { controller = "Roles" });

app.MapControllerRoute(
    name: "topics",
    pattern: "topics/{action=Index}/{id?}",
    defaults: new { controller = "Topics" });

app.MapControllerRoute(
    name: "collections",
    pattern: "collections/{action=Index}/{id?}",
    defaults: new { controller = "Collections" });

app.MapControllerRoute(
    name: "authors",
    pattern: "authors/{action=Index}/{id?}",
    defaults: new { controller = "Authors" });

app.MapControllerRoute(
    name: "books-admin",
    pattern: "books/{action=Index}/{id?}",
    defaults: new { controller = "Books" });

app.MapControllerRoute(
    name: "books",
    pattern: "books/{action=IndexBook}/{id?}",
    defaults: new { controller = "Books" });

app.MapControllerRoute(
    name: "usuarios",
    pattern: "usuarios/{action=Index}/{id?}",
    defaults: new { controller = "Usuario" });

app.MapControllerRoute(
    name: "usuariobooks",
    pattern: "usuariobooks/{action=Index}/{id?}",
    defaults: new { controller = "UsuarioBook" });

app.MapControllerRoute(
    name: "register",
    pattern: "/register",
    defaults: new { controller = "Auth", action = "Register" });

app.MapControllerRoute(
    name: "dashboard",
    pattern: "dashboard",
    defaults: new { controller = "Books", action = "Dashboard" }
);

// Ruta predeterminada que redirige a Login
app.MapControllerRoute(
    name: "default",
    pattern: "/",
    defaults: new { controller = "Auth", action = "Login" })
    .WithStaticAssets();

// Ruta para mandar al NotFound
app.MapControllerRoute(
    name: "NotFound",
    pattern: "NotFound",
    defaults: new { controller = "Home", action = "NotFound" });

app.Run();
