using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.News.Models;

namespace NewsApp.Endpoints.UI.News.Services
{
    public interface INewsService
    {
        Task<ApiResult<long>> CreateAsync(CreateNewsModel model);
        Task<ApiResult<long>> UpdateAsync(UpdateNewsModel model);
        Task<ApiResult<NewsDto>> GetByIdAsync(long id);
        Task<ApiResult<PagedData<NewsDto>>> GetPagedListAsync(PageQuery query);
        Task<ApiResult> DeleteAsync(long id);
    }
}
