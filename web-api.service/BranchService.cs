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
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<IEnumerable<Branch>> GetAllAsync(string? address)
        {
            var branches = await _branchRepository.GetAllAsync();
            if (address != null)
            {
                return branches.Where(e => e.Address == address).ToList();
            }
            return branches;
        }


        public Branch GetById(int id)
        {
            return _branchRepository.GetById(id);
            //return _context.Branches.Find(e => e.id == id);
        }


        public async Task<Branch> PostAsync(Branch value)
        {
            return await _branchRepository.PostAsync(value);
            //_context.Branches.Add(value);
        }


        public Task<Branch> PutAsync(int id, Branch value)
        {
            return _branchRepository.PutAsync(id, value);
            //_context.Branches.Remove(_context.Branches.Find(e => e.id == id));
            //_context.Branches.Add(value);

        }

        public async Task<Branch> PutAsync(int id, string address)
        {
            return await _branchRepository.PutAsync(id, address);
            //Branch b = _context.Branches.Find(e => e.id == id);
            //_context.Branches.Remove(_context.Branches.Find(e => e.id == id));
            //b.address = address;
            //_context.Branches.Add(b);
        }


        public async Task<Branch> DeleteAsync(int id)
        {
            return await _branchRepository.DeleteAsync(id);
            //_context.Branches.Remove(_context.Branches.Find(e => e.id == id));
        }
    }
}
