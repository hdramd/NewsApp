using Refit;
using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;

namespace NewsApp.Endpoints.UI.Categories.Services
{
    [Headers("Content-Type: application/json")]
    public interface ICategoryApi
    {
        [Post("/Category")]
        Task<long> CreateAsync([Body] CreateCategoryModel model);

        [Put("/Category")]
        Task<long> UpdateAsync([Body] UpdateCategoryModel model);

        [Get("/Category/{id}")]
        Task<CategoryDto> GetAsync(long id);

        [Get("/Category/GetPagedList")]
        Task<PagedData<CategoryDto>> GetPagedListAsync(PageQuery query);

        [Delete("/Category/{id}")]
        Task DeleteAsync(long id);
    }
}
