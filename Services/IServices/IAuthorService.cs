using System.Collections.Generic;
using BibliotecaSánchezLobatoGael83.Models.Domain;
using System.Threading.Tasks;

namespace BibliotecaSánchezLobatoGael83.Services.Interfaces
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
