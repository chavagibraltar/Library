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
    public class BranchRepository : IBranchRepository
    {
        private readonly DataContext _context;
        public BranchRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            //if (address != null)
            //{
            //   return _context.Branches.FindAll(e => e.address == address).ToList();
            // }
            return await _context.Branches.ToListAsync();
            //return _context.Branches;
        }

        public Branch GetById(int id)
        {
            return _context.Branches.Find(id);
        }

        public async Task<Branch> PostAsync(Branch value)
        {
            _context.Branches.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Branch> PutAsync(int id, Branch value)
        {
            Branch b = _context.Branches.Find(id);
            if (b != null)
            {
                b.Name = value.Name;
                b.Address = value.Address;
                b.PhoneNumber = value.PhoneNumber;
            }
            //  _context.Branches.Remove(_context.Branches.Find(id));
            //_context.Branches.Add(value);
            await _context.SaveChangesAsync();
            return value;         
        }

        public async Task<Branch> PutAsync(int id, string address)
        {
            Branch b = _context.Branches.Find(id);
            if (b != null)          
                b.Address = address;

            //  _context.Branches.Remove(_context.Branches.Find(id));
            //_context.Branches.Add(value);      
            await _context.SaveChangesAsync();
            return b;
        }

        public async Task<Branch> DeleteAsync(int id)
        {
            Branch b = _context.Branches.Find(id);
            if (b != null)
                _context.Branches.Remove(b);
            await _context.SaveChangesAsync();
            return b;
        }
    }
}
