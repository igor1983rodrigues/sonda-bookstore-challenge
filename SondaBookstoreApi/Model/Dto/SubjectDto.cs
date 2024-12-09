using SondaBookstoreApi.Model.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SondaBookstoreApi.Model.Dto
{
    public class SubjectDto
    {
        public int? Id { get; set; }

        public string Description { get; set; }
    }
}
