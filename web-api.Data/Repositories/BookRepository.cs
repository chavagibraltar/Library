using Microsoft.EntityFrameworkCore;
using web_api.core.Repositories;
using web_api.Core.Entities;

namespace web_api.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            //if (statusIsRented != null)
            //{
            //    return _context.Books.Where(x => x.statusIsRented == statusIsRented).ToList();
            //}
            //return await _context.Customers.ToListAsync();
            return await _context.Books.ToListAsync();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }
        public async Task<Book> PostAsync(Book value)
        {
            _context.Books.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }
        public async Task<Book> PutAsync(int id,  Book value)
        {
            Book b = _context.Books.Find(id);
            if (b != null)
            {
                b.Name = value.Name;
                b.StatusIsRented = value.StatusIsRented;
                b.BranchId = value.BranchId;        
            }
               // _context.Books.Remove(_context.Books.Find(id));
            //_context.Books.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }
        public async Task<Book> PutAsync(int id, bool statusIsRented)
        {
            Book b = _context.Books.Find(id);
            if(b!=null)
                b.StatusIsRented = statusIsRented;
            await _context.SaveChangesAsync();
            return b;      
        }
        public async Task<Book> DeleteAsync(int id)
        {
            Book b = _context.Books.Find(id);
            if (b != null)
            {
                _context.Books.Remove(b);
            }
            await _context.SaveChangesAsync();
            return b;
        }
    }
}
