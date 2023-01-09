using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.News.Models;
using Refit;

namespace NewsApp.Endpoints.UI.News.Services
{
    [Headers("Content-Type: application/json")]
    public interface INewsApi
    {
        [Post("/News")]
        Task<long> CreateAsync([Body] CreateNewsModel model);

        [Put("/News")]
        Task<long> UpdateAsync([Body] UpdateNewsModel model);

        [Get("/News/{id}")]
        Task<NewsDto> GetAsync(long id);

        [Get("/News/GetPagedList")]
        Task<PagedData<NewsDto>> GetPagedListAsync(PageQuery query);

        [Delete("/News/{id}")]
        Task DeleteAsync(long id);
    }
}

