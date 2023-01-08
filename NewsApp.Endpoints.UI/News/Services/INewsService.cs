using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.News.Models;

namespace NewsApp.Endpoints.UI.News.Services
{
    public interface INewsService
    {
        Task<long> CreateAsync(CreateNewsModel model);
        Task<long> UpdateAsync(UpdateNewsModel model);
        Task<NewsDto> GetByIdAsync(long id);
        Task<PagedData<NewsDto>> GetPagedListAsync();
        Task DeleteAsync(long id);
    }
}
