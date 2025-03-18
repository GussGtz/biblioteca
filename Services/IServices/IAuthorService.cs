using System.Collections.Generic;
using BibliotecaGustavoGtz.Models.Domain;
using System.Threading.Tasks;

namespace BibliotecaGustavoGtz.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);
        Task<int> CountAuthorsAsync();
    }
}
