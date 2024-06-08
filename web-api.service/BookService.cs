using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Core.Entities;
using web_api.core.Service;
using web_api.core.Repositories;

namespace web_api.service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAsync(bool? statusIsRented)
        {
            var books =  await _bookRepository.GetAllAsync();
            if (statusIsRented != null)
            {
              return books.Where(x => x.StatusIsRented == statusIsRented).ToList();
            }
            return books;
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
            //return _context.Books.Find(x => x.id == id);
        }
        public async Task<Book> PostAsync(Book value)
        {
            return await _bookRepository.PostAsync(value);
            //_context.Books.Add(value);
        }
        public async Task<Book> PutAsync(int id, Book value)
        {
            return await _bookRepository.PutAsync(id, value);
            //_context.Books.Remove(_context.Books.Find(e => e.id == id));
            //_context.Books.Add(value);
        }
        public async Task<Book> PutAsync(int id, bool statusIsRented)
        {
            return await _bookRepository.PutAsync(id, statusIsRented);
            //Book b = _context.Books.Find(e => e.id == id);
            //b.statusIsRented = statusIsRented;
            //_context.Books.Remove(_context.Books.Find(e => e.id == id));
            //_context.Books.Add(b);
        }
        public async Task<Book> DeleteAsync(int id)
        {
            return await _bookRepository.DeleteAsync(id);
            //_context.Books.Remove(_context.Books.Find(e => e.id == id));
        }
    }
}
