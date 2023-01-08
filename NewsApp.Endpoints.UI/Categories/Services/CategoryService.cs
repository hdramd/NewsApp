using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;

namespace NewsApp.Endpoints.UI.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryApi _categoryApi;
        public CategoryService(ICategoryApi categoryApi)
        {
            _categoryApi = categoryApi;
        }

        public Task<PagedData<CategoryDto>> GetPagedListAsync()
            => _categoryApi.GetPagedListAsync();
    }
}

