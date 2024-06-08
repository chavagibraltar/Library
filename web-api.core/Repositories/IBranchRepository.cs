using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Core.Entities;

namespace web_api.core.Repositories
{
    public interface IBranchRepository
    {
        public Task<IEnumerable<Branch>> GetAllAsync();

        public Branch GetById(int id);

        public Task<Branch> PostAsync(Branch value);

        public Task<Branch> PutAsync(int id, Branch value);

        public Task<Branch> PutAsync(int id, string address);

        public Task<Branch> DeleteAsync(int id);

    }
}
