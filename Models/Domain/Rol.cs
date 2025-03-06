using System.ComponentModel.DataAnnotations;

namespace BibliotecaSánchezLobatoGael83.Models.Domain
{
    public class Rol
    {
        [Key]
        public int PkRol {  get; set; }
        public string Nombre { get; set; }
        public DateTime Added_on { get; set; }
        public DateTime Updated_on { get; set; }
    }
}
