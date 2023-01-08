using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;
using Refit;

namespace NewsApp.Endpoints.UI.Categories.Services
{
    [Headers("Content-Type: application/json")]
    public interface ICategoryApi
    {
        [Get("/GetPagedList")]
        Task<PagedData<CategoryDto>> GetPagedListAsync();
    }
}
