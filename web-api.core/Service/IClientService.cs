using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Core.Entities;
using web_api.core.Repositories;

namespace web_api.core.Service
{
    public interface IClientService
    {
        public Task<IEnumerable<Client>> GetAsync(bool? hasBook);

        public Client GetById(int id);

        public Task<Client> PostAsync(Client value);

        public Task<Client> PutAsync(int id, Client value);

        public Task<Client> DeleteAsync(int id);
    
    }
}
