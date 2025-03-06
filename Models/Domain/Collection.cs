using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaSánchezLobatoGael83.Models.Domain
{
    public class Collection
    {
        [Key]
        public int PkCollection {  get; set; }
        public string Name_collection { get; set; }
        [ForeignKey("Authors")]
        public int FKAuthor { get; set; }
        public Author Authors { get; set; }
        [ForeignKey("Topics")]
        public int FKTopic { get; set; }
        public Topic Topics { get; set; }
        public int Pieces { get; set; }
        public DateTime Added_on { get; set; }
        public DateTime Updated_on { get; set; }
    }
}
