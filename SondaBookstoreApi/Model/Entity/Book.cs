using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SondaBookstoreApi.Model.Entity
{
    [Table("Livro")]
    public class Book
    {
        [Key]
        [Column("Codl")]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [Column("Titulo")]
        public string Title { get; set; }  

        [Required]
        [StringLength(40)]
        [Column("Editora")]
        public string Publisher { get; set; } 

        [Required]
        [Column("Edicao")]
        public int Edition { get; set; } 

        [Required]
        [StringLength(4)]
        [Column("AnoPublicacao")]
        public int PublishingYear { get; set; }
        
        public IEnumerable<BookAuthor> BookAuthors { get; set; }

        public IEnumerable<BookSubject> BookSubjects { get; set; }
    }
}
