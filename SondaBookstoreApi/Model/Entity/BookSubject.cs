using System.ComponentModel.DataAnnotations.Schema;

namespace SondaBookstoreApi.Model.Entity
{
    public class BookSubject
    {
        [Column("Livro_Codl")]
        public int IdBook { get; set; }
        
        [Column("Autor_CodAu")]
        public int IdSubject { get; set; }
        
        public Book Book { get; set; }
        
        public Subject Subject { get; set; }
    }
}
