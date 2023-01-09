using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;

namespace NewsApp.Endpoints.UI.Categories.Services
{
    public interface ICategoryService
    {
        Task<ApiResult<long>> CreateAsync(CreateCategoryModel model);
        Task<ApiResult<long>> UpdateAsync(UpdateCategoryModel model);
        Task<ApiResult<CategoryDto>> GetByIdAsync(long id);
        Task<ApiResult<PagedData<CategoryDto>>> GetPagedListAsync(PageQuery query);
        Task<ApiResult> DeleteAsync(long id);
    }
}
