using Microsoft.AspNetCore.Mvc;

namespace SondaBookstoreApi.Helper
{
    public interface IBaseController<TKey, TObject>
    {
        Task<IActionResult> FindAll();
        Task<IActionResult> FindById(TKey id);
        Task<IActionResult> Create(TObject body);
        Task<IActionResult> Update(TKey id, TObject body);
        Task<IActionResult> Remove(TKey id);
    }
}
