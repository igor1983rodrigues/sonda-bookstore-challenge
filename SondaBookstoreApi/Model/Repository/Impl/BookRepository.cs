using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model.Entity;

namespace SondaBookstoreApi.Model.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly SondaBookstoreContext context;

        public BookRepository(SondaBookstoreContext context)
        {
            this.context = context;
        }

        public void Delete(Book entity)
        {
            context.Books.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Book> FindAll()
        {
            return context.Books.ToList();
        }

        public Book FindById(int id)
        {
            Book? book = context.Books.Find(id);

            if (book == null)
            {
                throw new BusinessException("Livro não encontrado");
            }

            return book;
        }

        public int Save(Book entity)
        {
            if (entity.Id == 0)
            {
                context.Books.Add(entity);
            } else
            {
                context.Update(entity);
            }
 
            context.SaveChanges();
            
            return entity.Id;
        }
    }
}
