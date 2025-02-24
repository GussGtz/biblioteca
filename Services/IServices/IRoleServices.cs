using BibliotecaSánchezLobatoGael83.Models.Domain;

namespace BibliotecaSánchezLobatoGael83.Services.IServices
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