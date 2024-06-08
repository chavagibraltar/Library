using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using web_api.core.Dtos;
using web_api.core.Service;
using web_api.Core.Entities;
using web_api.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //public static Book b = new Book();
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        //public BookController(IBookService bookService)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        //public static List<Book> bl = new List<Book> {};
        //private DataContext dataContext = new DataContext();
        // GET: api/<BooksController>
        [HttpGet]
        //public IEnumerable<Book> Get(bool? statusIsRented)
        public async Task<ActionResult> Get(bool? statusIsRented)
        {
            var list = await _bookService.GetAsync(statusIsRented);
            var listDto = list.Select(b => _mapper.Map<BookDto>(b));
            return Ok(listDto);
            //return _bookService.Get(statusIsRented);
            //if (statusIsRented != null)
            //{
            //    return dataContext.Books.Where(x => x.statusIsRented == statusIsRented).ToList();
            //}
            //return dataContext.Books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {         
            //return dataContext.Books.Find(x => x.id == id);            
            //return _bookService.Get(id);
            return Ok(_mapper.Map<BookDto>(_bookService.GetById(id)));
            //var user = _userService.GetById(id);
            //var userDto = _mapper.Map<UserDto>(user);
            //return Ok(userDto);
        }        

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookPostModel value)
        //public ActionResult Post([FromBody] Book value)
        {
            //dataContext.Books.Add(value);
            //return Ok(_mapper.Map<BookDto>(_bookService.Post(_mapper.Map<Book>(value))));
            var bookToAdd = _mapper.Map<Book>(value);
            var addedBook = await _bookService.PostAsync(bookToAdd);
            return Ok(_mapper.Map<BookDto>(addedBook));
            //return Ok(_bookService.Post(value));
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BookPostModel value)
        {
            //dataContext.Books.Remove(dataContext.Books.Find(e => e.id == id));
            //dataContext.Books.Add(value);
            var bookToUpdate = _mapper.Map<Book>(value);
            var UpdateedBook = await _bookService.PutAsync(id ,bookToUpdate);

            return Ok(_mapper.Map<BookDto>(UpdateedBook));
            //return Ok(_bookService.Put(id, value));
        }
        [HttpPut("{id}/statusIsRented")]
        public async Task<ActionResult> Put(int id, [FromBody] bool statusIsRented)
        {
            //b = dataContext.Books.Find(e => e.id == id);
            //b.statusIsRented = statusIsRented;
            //dataContext.Books.Remove(dataContext.Books.Find(e => e.id == id));
            //dataContext.Books.Add(b);
            return Ok(await _bookService.PutAsync(id, statusIsRented));
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //dataContext.Books.Remove(dataContext.Books.Find(e => e.id == id));
            return Ok(await _bookService.DeleteAsync(id));
        }
    }
}
