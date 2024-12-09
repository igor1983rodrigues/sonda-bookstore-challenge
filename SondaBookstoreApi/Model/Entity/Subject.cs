using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SondaBookstoreApi.Model.Entity
{
    [Table("Assunto")]
    public class Subject
    {
        [Key]
        [Column("codAs")]
        public int Id { get; set; }

        [Required]
        [Column("Descricao")]
        [StringLength(20)]
        public string Description { get; set; }
        public IEnumerable<BookSubject> BookSubjects { get; set; }
    }
}
