using SondaBookstoreApi.Model.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SondaBookstoreApi.Model.Dto
{
    public class BookDto
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public int Edition { get; set; }

        public int PublishingYear { get; set; }
    }
}
