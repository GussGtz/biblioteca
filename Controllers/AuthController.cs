using Azure;
using BibliotecaGustavoGtz.Models.Domain;
using BibliotecaGustavoGtz.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
public class AuthController : Controller
{
    private readonly IUsuarioServices _usuarioServices;
    private readonly IConfiguration _configuration;

    public AuthController(IUsuarioServices usuarioServices, IConfiguration configuration)
    {
        _usuarioServices = usuarioServices;
        _configuration = configuration;
    }

    // Vista Login
    public IActionResult Login()
    {
        return View();
    }

    // Acción para iniciar sesión
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string username, string password)
    {
        var usuario = _usuarioServices.Login(username, password);

        if (usuario != null)
        {
            // Generar el JWT Token
            var token = GenerateJwtToken(usuario);

            // Almacenar el token en una cookie segura
            Response.Cookies.Append("JwtToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            return RedirectToAction("IndexBook", "Books");
        }

        return Unauthorized();
    }


    // Vista Registro
    public IActionResult Register()
    {
        return View();
    }

    // Acción para registrar un usuario
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(string Nombre, string UserName, string Password)
    {
        var usuario = new Usuario
        {
            Nombre = Nombre,
            UserName = UserName,
            // Hashear la contraseña antes de guardarla
            Password = _usuarioServices.HashPassword(Password),
            FKRol = 2, // Asignar el rol por defecto
            Added_on = DateTime.Now
        };

        _usuarioServices.Register(usuario);
        return RedirectToAction("Login");
    }

    // Generar JWT Token
    private string GenerateJwtToken(Usuario usuario)
    {
        // Obtén el nombre del rol desde la propiedad de navegación
        var roleName = usuario.Roles?.Nombre ?? "Guest";  // Usa "Guest" como valor por defecto si no hay rol

        var claims = new[]
        {
        new Claim(ClaimTypes.Name, usuario.UserName),
        new Claim(ClaimTypes.NameIdentifier, usuario.PkUsuario.ToString()),
        new Claim(ClaimTypes.Role, roleName)  // Usa el nombre del rol
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "BibliotecaAPI",
            audience: "BibliotecaClient",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    // Acción para desloguearse
    public IActionResult Logout()
    {
        // Eliminar la cookie de autenticación (si se usa)
        Response.Cookies.Delete("JwtToken");

        // Limpiar la sesión del usuario

        // Redirigir al login o a la página de inicio
        return RedirectToAction("Login", "Auth");
    }
}