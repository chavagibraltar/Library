using Microsoft.AspNetCore.Mvc;
using web_api.core.Service;
using web_api.Core.Entities;
using AutoMapper;
using web_api.core.Dtos;
using web_api.service;
using web_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        /*
        public static List<Book> booksList_ = new List<Book> {
        new Book { id = 1, name = "aaa", statusIsRented = true, branchId = 1 },
        new Book { id = 2, name = "bbb", statusIsRented = false, branchId = 1 },
        new Book { id = 3, name = "ccc", statusIsRented = true, branchId = 2 },
        new Book { id = 4, name = "ddd", statusIsRented = false, branchId = 2 },};

        public static List<Book> booksList1 = new List<Book> {
        new Book { id = 1, name = "aaa", statusIsRented = true, branchId = 1 },
        new Book { id = 2, name = "bbb", statusIsRented = false, branchId = 1 } };
        public static List<Book> booksList2 = new List<Book> {
        new Book { id = 3, name = "ccc", statusIsRented = true, branchId = 2 },
        new Book { id = 4, name = "ddd", statusIsRented = false, branchId = 2 },};
        public static List<Client> clients = new List<Client> {
            new Client { id = 1, name = "a", booksList = {1,2,3}, hasBook = true , branchId = 1, phoneNumber = "050-1111111"},
            new Client { id = 1, name = "b", booksList = {4,5,6}, hasBook = false , branchId = 1, phoneNumber = "050-2222222"},
            new Client { id = 1, name = "c", booksList = {7,8,9}, hasBook = true , branchId = 2, phoneNumber = "050-3333333"}};
        */

       // public Branch b  = new Branch();
       // private DataContext dataContext;
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;
        public BranchController(IBranchService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }
        //public BranchesController(DataContext context)
        //{
        //    dataContext = context;
        //}
    
        // GET: api/<BranchesController>
        [HttpGet]
        //public IEnumerable<Branch> Get(string? address)
        public async Task<ActionResult> Get(string? address)
        {
            var list = await _branchService.GetAllAsync(address);
            var listDto = list.Select(b => _mapper.Map<BranchDto>(b));
            return Ok(listDto);
            //return _branchService.Get(address);
            //if(address != null)
            //{
            //    return dataContext.Branches.FindAll(e => e.address == address).ToList();
            //}
            //return dataContext.Branches;
        }

        // GET api/<BranchesController>/5
        [HttpGet("{id}")]
        //public Branch Get(int id)
        public ActionResult Get(int id)
        {
            return Ok(_mapper.Map<BranchDto>(_branchService.GetById(id)));
            //return _branchService.Get(id);
            //return dataContext.Branches.Find(e => e.id == id);
        }

        // POST api/<BranchesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BranchPostModel value)
        {
            var branchToAdd = _mapper.Map<Branch>(value);
            var addedBranch = await _branchService.PostAsync(branchToAdd);
            return Ok(_mapper.Map<BranchDto>(addedBranch));
            //return Ok(_branchService.Post(value));
            //dataContext.Branches.Add(value);
        }

        // PUT api/<BranchesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BranchPostModel value)
        {
            var branchToUpdate = _mapper.Map<Branch>(value);
            var UpdateedBranch = await _branchService.PutAsync(id, branchToUpdate);
            return Ok(_mapper.Map<BranchDto>(UpdateedBranch));
            //return Ok(_branchService.Put(id, value));
            //dataContext.Branches.Remove(dataContext.Branches.Find(e => e.id == id));
            //dataContext.Branches.Add(value);
           
        }
        [HttpPut("{id}/adress")]
        public async Task<ActionResult> Put(int id, [FromBody] string address)
        {
            //var branchToUpdate = _mapper.Map<Branch>(address);
            var UpdateedBranch = await _branchService.PutAsync(id, address);
            return Ok(_mapper.Map<BranchDto>(UpdateedBranch));
            //return Ok(_branchService.Put(id, address));
            //b = dataContext.Branches.Find(e => e.id == id);
            //dataContext.Branches.Remove(dataContext.Branches.Find(e => e.id == id));
            //b.address = address;
            //dataContext.Branches.Add(b);
        }

        // DELETE api/<BranchesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _branchService.DeleteAsync(id));
            //dataContext.Branches.Remove(dataContext.Branches.Find(e => e.id == id));
        }
    }
}
