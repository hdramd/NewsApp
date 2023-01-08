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

        public async Task<long> CreateAsync(CreateCategoryModel model)
            => await _categoryApi.CreateAsync(model);

        public async Task<PagedData<CategoryDto>> GetPagedListAsync()
            => await _categoryApi.GetPagedListAsync();

    }
}

