using Microsoft.AspNetCore.Mvc;
using SondaBookstoreApi.Business;
using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model.Dto;

namespace SondaAuthorstoreApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase, IBaseController<int, AuthorDto>
    {
        private readonly IAuthorBusiness business;

        public AuthorController(IAuthorBusiness business)
        {
            this.business = business;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await Task.Run(() => business.Delete(id));

            return Ok(new { Message = "Autor removido com sucesso" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            AuthorDto Author = await Task.Run(() => business.FindById(id));

            return Ok(Author);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            IEnumerable<AuthorDto> AuthorList = await Task.Run(() => business.FindAll());

            return Ok(AuthorList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorDto body)
        {
            int id = await Task.Run(() => business.Create(body));
            body.Id = id;

            return Ok(body);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AuthorDto body)
        {
            AuthorDto Author = await Task.Run(() => business.Update(id, body));

            return Ok(body);
        }
    }
}
