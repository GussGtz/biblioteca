using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaGustavoGtz.Models.Domain
{
    public class UsuarioBook
    {
        [Key]
        public int PkUsuarioBook { get; set; }

        [ForeignKey("Usuario")]
        public int FKUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Book")]
        public int FKBook { get; set; }
        public Book Book { get; set; }

        public DateTime Added_on { get; set; } = DateTime.Now;
    }
}
