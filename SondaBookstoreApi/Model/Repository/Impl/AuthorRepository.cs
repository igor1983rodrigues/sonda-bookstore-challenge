using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model.Entity;

namespace SondaBookstoreApi.Model.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly SondaBookstoreContext context;

        public AuthorRepository(SondaBookstoreContext context)
        {
            this.context = context;
        }

        public void Delete(Author entity)
        {
            context.Authors.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Author> FindAll()
        {
            return context.Authors.ToList();
        }

        public Author FindById(int id)
        {
            Author? author = context.Authors.Find(id);

            if (author == null)
            {
                throw new BusinessException("Autor não encontrado");
            }

            return author;
        }

        public int Save(Author entity)
        {
            if (entity.Id == 0)
            {
                context.Authors.Add(entity);
            }
            else
            {
                context.Update(entity);
            }

            context.SaveChanges();

            return entity.Id;
        }
    }
}
