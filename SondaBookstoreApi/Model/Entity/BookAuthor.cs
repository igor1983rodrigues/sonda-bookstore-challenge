using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SondaBookstoreApi.Model.Entity
{
    [Table("Livro_Autor")]
    public class BookAuthor
    {
        [Column("Livro_Codl")]
        public int IdBook { get; set; }

        [Column("Autor_CodAu")]
        public int IdAuthor { get; set; }
        
        [ForeignKey("Livro_Codl_FK")]
        public Book Book { get; set; }
        
        [ForeignKey("Autor_CodAu_FK")]
        public Author Author { get; set; }
    }
}
