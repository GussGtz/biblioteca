using BibliotecaSánchezLobatoGael83.Models.Domain;

namespace BibliotecaSánchezLobatoGael83.Services.IServices
{
    public interface IUsuarioServices
    {
        List<Usuario> ObtenerUsuarios();
        bool CrearUsuario(Usuario request);
        Usuario GetUsuarioById(int id);
        bool EditarUsuario(Usuario request);
        bool EliminarUsuario(int id);
        public List<Rol> GetRoles();
    }

}
