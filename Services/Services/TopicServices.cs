using BibliotecaSánchezLobatoGael83.Context;
using BibliotecaSánchezLobatoGael83.Models.Domain;
using BibliotecaSánchezLobatoGael83.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaSánchezLobatoGael83.Services.Services
{
    public class TopicServices : ITopicServices
    {
        private readonly ApplicationDbContext _context;

        public TopicServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountTopicsAsync()
        {
            return await _context.Topics.CountAsync();
        }

        public List<Topic> ObtenerTopics()
        {
            return _context.Topics.ToList();
        }

        public bool CrearTopic(Topic topic)
        {
            try
            {
                _context.Topics.Add(topic);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Topic GetTopicById(int id)
        {
            return _context.Topics.Find(id);
        }

        public bool EditarTopic(Topic topic)
        {
            try
            {
                _context.Topics.Update(topic);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarTopic(int id)
        {
            try
            {
                var topic = _context.Topics.Find(id);
                if (topic != null)
                {
                    _context.Topics.Remove(topic);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}