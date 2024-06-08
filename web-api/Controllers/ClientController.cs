using Microsoft.AspNetCore.Mvc;
using web_api.core.Service;
using web_api.Core.Entities;
using AutoMapper;
using System.Net;
using web_api.core.Dtos;
using web_api.service;
using web_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        /*
        public static List<Book> booksList1 = new List<Book> {
        new Book { id = 1, name = "aaa", statusIsRented = true, branchId = 1 },
        new Book { id = 2, name = "bbb", statusIsRented = false, branchId = 1 } };
        public static List<Book> booksList2 = new List<Book> {
        new Book { id = 3, name = "ccc", statusIsRented = true, branchId = 2 },
        new Book { id = 4, name = "ddd", statusIsRented = false, branchId = 2 },};
        */

        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        //private DataContext dataContext;
        //public ClientsController(DataContext context)
        //{
        //    dataContext = context;
        //}
        // GET: api/<ClientsController>
        [HttpGet]
        //public IEnumerable<Client> Get([FromBody] bool? hasBook)
        public async Task<ActionResult> Get([FromBody] bool? hasBook)
        {
            var list = await _clientService.GetAsync(hasBook);
            var listDto = list.Select(c => _mapper.Map<ClientDto>(c));
            return Ok(listDto);
            //return _clientService.Get(hasBook);
            //if(hasBook != null)
            //{
            //    return dataContext.Clients.FindAll(e=>e.hasBook == hasBook).ToList();
            //}
            //return dataContext.Clients;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        //public ClientDto Get(int id)
       public ActionResult Get(int id)
        {
            //return _mapper.Map<ClientDto>(_clientService.Get(id));    
            return Ok(_mapper.Map<ClientDto>(_clientService.GetById(id)));
            //return _clientService.Get(id);
            //return dataContext.Clients.Find(e=>e.id == id);        
        }        

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientPostModel value)
        {
            var clientToAdd = _mapper.Map<Client>(value);
            var addedClient = await _clientService.PostAsync(clientToAdd);
            return Ok(_mapper.Map<ClientDto>(addedClient));
            //return Ok(_clientService.Post(value));
            //dataContext.Clients.Add(value);
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientPostModel value)
        {
            var clientToUpdate = _mapper.Map<Client>(value);
            var UpdateedClient = await _clientService.PutAsync(id, clientToUpdate);
            return Ok(_mapper.Map<ClientDto>(UpdateedClient));
            //return Ok(_clientService.Put(id, value));
            //dataContext.Clients.Remove(dataContext.Clients.Find(e => e.id == id));
            //dataContext.Clients.Add(value);            
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _clientService.DeleteAsync(id));
            //dataContext.Clients.Remove(dataContext.Clients.Find(e => e.id == id));
        }
    }
}
