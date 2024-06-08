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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public async Task<IEnumerable<Client>> GetAsync(bool? hasBook)
        {
            var clients = await _clientRepository.GetAllAsync();
            if (hasBook != null)
            {
                return clients.Where(e => e.HasBook == hasBook).ToList();
            }
            return clients;
        }

        public Client GetById(int id)
        {
            return _clientRepository.GetById(id);
            //return _context.Clients.Find(e => e.id == id);
        }


        public async Task<Client> PostAsync(Client value)
        {
            return await _clientRepository.PostAsync(value);
            //_context.Clients.Add(value);
        }


        public async Task<Client> PutAsync(int id, Client value)
        {
            return await _clientRepository.PutAsync(id, value);
            //_context.Clients.Remove(_context.Clients.Find(e => e.id == id));
            //_context.Clients.Add(value);
        }

        public async Task<Client> DeleteAsync(int id)
        {
            return await _clientRepository.DeleteAsync(id);
            //_context.Clients.Remove(_context.Clients.Find(e => e.id == id));
        }

    }
}
