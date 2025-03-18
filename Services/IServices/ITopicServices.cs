using BibliotecaGustavoGtz.Models.Domain;

namespace BibliotecaGustavoGtz.Services.IServices
{
    public interface ITopicServices
    {
        List<Topic> ObtenerTopics();
        bool CrearTopic(Topic topic);
        Topic GetTopicById(int id);
        bool EditarTopic(Topic topic);
        bool EliminarTopic(int id);
        Task<int> CountTopicsAsync();
    }
}
