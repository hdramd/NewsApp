using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.Shared.Services;
using NewsApp.Endpoints.UI.News.Models;
using Refit;

namespace NewsApp.Endpoints.UI.News.Services
{
    public class NewsService : ServiceBase, INewsService
    {
        private readonly INewsApi _newsApi;
        public NewsService(INewsApi newsApi)
        {
            _newsApi = newsApi;
        }

        public async Task<ApiResult<long>> CreateAsync(CreateNewsModel model)
        {
            try
            {
                var newsId = await _newsApi.CreateAsync(model);
                return ApiResult.Successfull(newsId);
            }
            catch (ApiException ex)
            {
                return await FailedResult<long>(ex);
            }
        }

        public async Task<ApiResult<long>> UpdateAsync(UpdateNewsModel model)
        {
            try
            {
                var newsId = await _newsApi.UpdateAsync(model);
                return ApiResult.Successfull(newsId);
            }
            catch (ApiException ex)
            {
                return await FailedResult<long>(ex);
            }
        }

        public async Task<ApiResult<NewsDto>> GetByIdAsync(long id)
        {
            try
            {
                var newsId = await _newsApi.GetAsync(id);
                return ApiResult.Successfull(newsId);
            }
            catch (ApiException ex)
            {
                return await FailedResult<NewsDto>(ex);
            }
        }

        public async Task<ApiResult<PagedData<NewsDto>>> GetPagedListAsync(PageQuery query)
        {
            try
            {
                var newsId = await _newsApi.GetPagedListAsync(query);
                return ApiResult.Successfull(newsId);
            }
            catch (ApiException ex)
            {
                return await FailedResult<PagedData<NewsDto>>(ex);
            }
        }

        public async Task<ApiResult> DeleteAsync(long id)
        {
            try
            {
                await _newsApi.DeleteAsync(id);
                return ApiResult.Successfull();
            }
            catch (ApiException ex)
            {
                return await FailedResult(ex);
            }
        }
    }
}
