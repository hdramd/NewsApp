using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;
using Refit;

namespace NewsApp.Endpoints.UI.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryApi _categoryApi;
        public CategoryService(ICategoryApi categoryApi)
        {
            _categoryApi = categoryApi;
        }

        public async Task<ApiResult<long>> CreateAsync(CreateCategoryModel model)
        {
            try
            {
                var categoryId = await _categoryApi.CreateAsync(model);
                return new ApiResult<long> { Succeeded = true, Data = categoryId };
            }
            catch (ApiException ex)
            {
                var errors = await ex.GetContentAsAsync<string[]>();
                return new ApiResult<long> { ErrorMessage = errors[0] };
            }
        }

        public async Task<long> UpdateAsync(UpdateCategoryModel model)
            => await _categoryApi.UpdateAsync(model);

        public async Task<CategoryDto> GetByIdAsync(long id)
            => await _categoryApi.GetAsync(id);

        public async Task<PagedData<CategoryDto>> GetPagedListAsync(PageQuery query)
            => await _categoryApi.GetPagedListAsync(query);

        public async Task DeleteAsync(long id)
            => await _categoryApi.DeleteAsync(id);

    }
}

