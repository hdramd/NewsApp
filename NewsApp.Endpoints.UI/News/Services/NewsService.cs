using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.News.Models;

namespace NewsApp.Endpoints.UI.News.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsApi _newsApi;
        public NewsService(INewsApi newsApi)
        {
            _newsApi= newsApi;
        }

        public async Task<long> CreateAsync(CreateNewsModel model)
            => await _newsApi.CreateAsync(model);

        public async Task<long> UpdateAsync(UpdateNewsModel model)
            => await _newsApi.UpdateAsync(model);

        public async Task<NewsDto> GetByIdAsync(long id)
            => await _newsApi.GetAsync(id);

        public async Task<PagedData<NewsDto>> GetPagedListAsync(PageQuery query)
            => await _newsApi.GetPagedListAsync(query);

        public async Task DeleteAsync(long id)
            => await _newsApi.DeleteAsync(id);
    }
}
