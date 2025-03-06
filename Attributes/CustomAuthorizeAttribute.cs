using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Verifica si el usuario está autenticado
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            // Redirigir a la página de inicio de sesión si no está autenticado
            context.Result = new RedirectToActionResult("Login", "Auth", null);
        }
        else
        {
            // Divide los roles separados por comas
            var allowedRoles = Roles?.Split(',').Select(r => r.Trim()).ToList();

            // Verifica si el usuario tiene al menos uno de los roles permitidos
            if (allowedRoles == null || !allowedRoles.Any(role => context.HttpContext.User.IsInRole(role)))
            {
                // Redirigir a la página de 404 si no tiene permisos
                context.Result = new RedirectToActionResult("NotFound", "Home", null);
            }
        }
    }
}