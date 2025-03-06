using System.ComponentModel.DataAnnotations;

namespace BibliotecaSánchezLobatoGael83.Models.Domain
{
    public class Author
    {
        [Key]
        public int PkAuthor {  get; set; }
        public string Name_author { get; set; }
        public DateTime Birth_date { get; set; }
        public string Description_author { get; set; }
        public int Num_works { get; set; }
        public string Origin { get; set; }
        public DateTime Added_on { get; set; }
        public DateTime Updated_on { get; set; }
    }
}
