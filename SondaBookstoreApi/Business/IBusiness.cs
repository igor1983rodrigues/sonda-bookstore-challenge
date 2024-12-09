namespace SondaBookstoreApi.Business
{
    public interface IBusiness<TKey, TDtoEntity>
    {
        TDtoEntity FindById(TKey id);
        IEnumerable<TDtoEntity> FindAll();
        TKey Create(TDtoEntity dto);
        TDtoEntity Update(TKey id, TDtoEntity dto);
        void Delete(TKey id);
    }
}
