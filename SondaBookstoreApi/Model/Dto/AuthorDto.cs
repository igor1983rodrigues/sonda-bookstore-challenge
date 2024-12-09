using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SondaBookstoreApi.Model.Dto
{
    public class AuthorDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }
    }
}
