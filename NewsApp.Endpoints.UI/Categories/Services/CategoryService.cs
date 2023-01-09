using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.Shared.Services;
using NewsApp.Endpoints.UI.Categories.Models;
using Refit;

namespace NewsApp.Endpoints.UI.Categories.Services
{
    public class CategoryService : ServiceBase, ICategoryService
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
                return ApiResult.Successfull(categoryId);
            }
            catch (ApiException ex)
            {
                return await FailedResult<long>(ex);
            }
        }

        public async Task<ApiResult<long>> UpdateAsync(UpdateCategoryModel model)
        {
            try
            {
                var categoryId = await _categoryApi.UpdateAsync(model);
                return ApiResult.Successfull(categoryId);
            }
            catch (ApiException ex)
            {
                return await FailedResult<long>(ex);
            }
        }

        public async Task<ApiResult<CategoryDto>> GetByIdAsync(long id)
        {
            try
            {
                var category = await _categoryApi.GetAsync(id);
                return ApiResult.Successfull(category);
            }
            catch (ApiException ex)
            {
                return await FailedResult<CategoryDto>(ex);
            }
        }

        public async Task<ApiResult<PagedData<CategoryDto>>> GetPagedListAsync(PageQuery query)
        {
            try
            {
                var data = await _categoryApi.GetPagedListAsync(query);
                return ApiResult.Successfull(data);
            }
            catch (ApiException ex)
            {
                return await FailedResult<PagedData<CategoryDto>>(ex);
            }
        }

        public async Task<ApiResult> DeleteAsync(long id)
        {
            try
            {
                await _categoryApi.DeleteAsync(id);
                return ApiResult.Successfull();
            }
            catch (ApiException ex)
            {
                return await FailedResult(ex);
            }
        }

    }
}

