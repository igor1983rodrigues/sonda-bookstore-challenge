using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model.Entity;

namespace SondaBookstoreApi.Model.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SondaBookstoreContext context;

        public SubjectRepository(SondaBookstoreContext context)
        {
            this.context = context;
        }

        public void Delete(Subject entity)
        {
            context.Subjects.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Subject> FindAll()
        {
            return context.Subjects.ToList();
        }

        public Subject FindById(int id)
        {
            Subject? subject = context.Subjects.Find(id);

            if (subject == null)
            {
                throw new BusinessException("Assunto não encontrado");
            }

            return subject;
        }

        public int Save(Subject entity)
        {
            if (entity.Id == 0)
            {
                context.Subjects.Add(entity);
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
