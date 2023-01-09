using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;

namespace NewsApp.Endpoints.UI.Categories.Services
{
    public interface ICategoryService
    {
        Task<long> CreateAsync(CreateCategoryModel model);
        Task<long> UpdateAsync(UpdateCategoryModel model);
        Task<CategoryDto> GetByIdAsync(long id);
        Task<PagedData<CategoryDto>> GetPagedListAsync(PageQuery query);
        Task DeleteAsync(long id);
    }
}
