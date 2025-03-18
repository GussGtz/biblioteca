using BibliotecaGustavoGtz.Models.Domain;

namespace BibliotecaGustavoGtz.Services.IServices
{
    public interface IRolServices
    {
        List<Rol> ObtenerRoles();
        bool CrearRol(Rol rol);
        Rol GetRolById(int id);
        bool EditarRol(Rol rol);
        bool EliminarRol(int id);
    }
}