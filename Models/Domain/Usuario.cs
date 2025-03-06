using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaSánchezLobatoGael83.Models.Domain
{
    public class Usuario
    {
        [Key]
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [ForeignKey("Roles")]
        public int FKRol {  get; set; }
        public Rol Roles { get; set; }
        public DateTime Added_on { get; set; }
        public DateTime Updated_on { get; set; }

        // Relación con la tabla pivote
        public ICollection<UsuarioBook> UsuarioBooks { get; set; }
    }
}
