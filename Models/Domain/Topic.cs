using System.ComponentModel.DataAnnotations;

namespace BibliotecaSánchezLobatoGael83.Models.Domain
{
    public class Topic
    {
        [Key]
        public int PkTopic {  get; set; }
        public string Name_topic { get; set; }
        public DateTime Added_on { get; set; }
        public DateTime Updated_on { get; set; }
    }
}
