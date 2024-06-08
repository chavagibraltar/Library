using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Core.Entities;
using web_api.core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace web_api.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }
     
        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            //if (hasBook != null)
            //{
             //   return _context.Clients.FindAll(e => e.hasBook == hasBook).ToList();
            //}
            return await _context.Clients.ToListAsync();
        }

        public Client GetById(int id)
        {
            return _context.Clients.Find(id);
        }

        public async Task<Client> PostAsync(Client value)
        {
            _context.Clients.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }
      
        public async Task<Client> PutAsync(int id, Client value)
        {
            Client c = _context.Clients.Find(id);
            if (c != null)
            {
                c.Name = value.Name;
                c.PhoneNumber = value.PhoneNumber;
                c.BranchId = value.BranchId;
                c.HasBook = value.HasBook;
            }
            // _context.Clients.Remove(_context.Clients.Find(id));
            //_context.Clients.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Client> DeleteAsync(int id)
        {
            Client c = _context.Clients.Find(id);
            _context.Clients.Remove(c);
            await _context.SaveChangesAsync();
            return c;
        }
    }
}
