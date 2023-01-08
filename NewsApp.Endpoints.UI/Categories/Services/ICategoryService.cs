using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;

namespace NewsApp.Endpoints.UI.Categories.Services
{
    public interface ICategoryService
    {
        Task<PagedData<CategoryDto>> GetPagedListAsync();
    }
}
