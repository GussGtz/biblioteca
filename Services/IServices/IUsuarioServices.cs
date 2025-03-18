using BibliotecaGustavoGtz.Models.Domain;

namespace BibliotecaGustavoGtz.Services.IServices
{
    public interface IUsuarioServices
    {
        List<Usuario> ObtenerUsuarios();
        bool CrearUsuario(Usuario request);
        Usuario GetUsuarioById(int id);
        bool EditarUsuario(Usuario request);
        bool EliminarUsuario(int id);
        public List<Rol> GetRoles();
        Usuario Login(string username, string password);
        void Register(Usuario usuario);
        string HashPassword(string password);
    }

}
