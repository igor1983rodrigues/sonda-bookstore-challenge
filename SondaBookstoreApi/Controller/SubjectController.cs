using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SondaBookstoreApi.Business;
using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model.Dto;

namespace SondaBookstoreApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase, IBaseController<int, SubjectDto>
    {
        private readonly ISubjectBusiness business;

        public SubjectController(ISubjectBusiness business)
        {
            this.business = business;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await Task.Run(() => business.Delete(id));

            return Ok(new { Message = "Assunto removido com sucesso" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            SubjectDto Subject = await Task.Run(() => business.FindById(id));

            return Ok(Subject);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            IEnumerable<SubjectDto> SubjectList = await Task.Run(() => business.FindAll());

            return Ok(SubjectList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectDto body)
        {
            int id = await Task.Run(() => business.Create(body));
            body.Id = id;

            return Ok(body);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubjectDto body)
        {
            SubjectDto Subject = await Task.Run(() => business.Update(id, body));

            return Ok(body);
        }
    }
}

