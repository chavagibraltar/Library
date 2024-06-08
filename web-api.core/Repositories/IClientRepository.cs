using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Core.Entities;

namespace web_api.core.Repositories
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetAllAsync();

        public Client GetById(int id);

        public Task<Client> PostAsync(Client value);

        public Task<Client> PutAsync(int id, Client value);

        public Task<Client> DeleteAsync(int id);
    }
}
