using BibliotecaGustavoGtz.Context;
using BibliotecaGustavoGtz.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaGustavoGtz.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly ApplicationDbContext _context;

        public CollectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountCollectionsAsync()
        {
            return await _context.Collections.CountAsync();
        }

        public async Task<IEnumerable<Collection>> GetAllCollectionsAsync()
        {
            return await _context.Collections
                .Include(c => c.Authors)
                .Include(c => c.Topics)
                .ToListAsync();
        }

        public async Task<Collection> GetCollectionByIdAsync(int id)
        {
            return await _context.Collections
                .Include(c => c.Authors)
                .Include(c => c.Topics)
                .FirstOrDefaultAsync(c => c.PkCollection == id);
        }

        public async Task AddCollectionAsync(Collection collection)
        {
            collection.Added_on = DateTime.Now;
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCollectionAsync(Collection collection)
        {
            collection.Updated_on = DateTime.Now;
            _context.Collections.Update(collection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCollectionAsync(int id)
        {
            var collection = await _context.Collections.FindAsync(id);
            if (collection != null)
            {
                _context.Collections.Remove(collection);
                await _context.SaveChangesAsync();
            }
        }
    }
}
