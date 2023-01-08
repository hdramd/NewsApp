using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;
using Refit;

namespace NewsApp.Endpoints.UI.Categories.Services
{
    [Headers("Content-Type: application/json")]
    public interface ICategoryApi
    {
        [Post("/")]
        Task<long> CreateAsync([Body]CreateCategoryModel model); 
        
        [Get("/GetPagedList")]
        Task<PagedData<CategoryDto>> GetPagedListAsync();
    }
}
