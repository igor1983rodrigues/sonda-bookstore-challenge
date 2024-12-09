using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SondaBookstoreApi.Business;
using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model.Dto;

namespace SondaBookstoreApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase, IBaseController<int, BookDto>
    {
        private readonly IBookBusiness business;

        public BookController(IBookBusiness business)
        {
            this.business = business;
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await Task.Run(() => business.Delete(id));

            return Ok(new { Message = "Livro removido com sucesso" });
        }
         
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            BookDto book = await Task.Run(() => business.FindById(id));

            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            IEnumerable<BookDto> bookList = await Task.Run(() => business.FindAll());

            return Ok(bookList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDto body)
        {
            int id = await Task.Run(() => business.Create(body));
            body.Id = id;

            return Ok(body);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookDto body)
        {
            BookDto book = await Task.Run(() => business.Update(id, body));

            return Ok(body);
        }
    }
}
