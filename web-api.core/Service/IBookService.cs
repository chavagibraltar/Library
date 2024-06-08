using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Core.Entities;
using web_api.core.Repositories;

namespace web_api.core.Service
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAsync(bool? statusIsRented);

        public Book GetById(int id);

        public Task<Book> PostAsync(Book value);

        public Task<Book> PutAsync(int id, Book value);

        public Task<Book> PutAsync(int id, bool statusIsRented);

        public Task<Book> DeleteAsync(int id);
  
    }
}
