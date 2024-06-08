using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Core.Entities;

namespace web_api.core.Repositories
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllAsync();

        public Book GetById(int id);

        public Task<Book> PostAsync(Book value);

        public Task<Book> PutAsync(int id, Book value);

        public Task<Book> PutAsync(int id, bool statusIsRented);

        public Task<Book> DeleteAsync(int id);

    }
}
