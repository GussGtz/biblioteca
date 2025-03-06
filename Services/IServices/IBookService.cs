using BibliotecaSánchezLobatoGael83.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaSánchezLobatoGael83.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<int> CountBooksAsync();
    }
}