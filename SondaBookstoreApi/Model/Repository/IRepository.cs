namespace SondaBookstoreApi.Model.Repository
{
    public interface IRepository<TKey, TEntity>
    {
        TEntity FindById(TKey id);
        IEnumerable<TEntity> FindAll();
        TKey Save(TEntity entity);
        void Delete(TEntity entity);
    }
}
