using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaSánchezLobatoGael83.Models.Domain
{
    public class Book
    {
        [Key]
        public int PkBook {  get; set; }
        public string Name_book { get; set; }
        [ForeignKey("Topics")]
        public int FKTopic { get; set; }
        public Topic Topics { get; set; }
        [ForeignKey("Collections")]
        public int? FKCollection { get; set; }
        public Collection Collections { get; set; }
        [ForeignKey("Authors")]
        public int FKAuthors { get; set; }
        public Author Authors { get; set; }
        public DateTime Year_published { get; set; }
        public int Num_pages { get; set; }
        public int Stock {  get; set; }
        public bool Sold_out { get; set; }
        public DateTime Added_on { get; set; }
        public DateTime Updated_on { get; set; }

        // Relación con la tabla pivote
        public ICollection<UsuarioBook> UsuarioBooks { get; set; }
    }
}
