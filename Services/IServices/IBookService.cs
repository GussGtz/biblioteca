using BibliotecaGustavoGtz.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaGustavoGtz.Services
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