using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SondaBookstoreApi.Model.Entity
{
    [Table("AUTOR")]
    public class Author
    {
        [Key]
        [Column("CodAu")]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        [StringLength(40)]
        public string Name { get; set; }

        public IEnumerable<BookAuthor> BookAuthors { get; set; }
    }
}
