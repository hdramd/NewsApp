using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.News.Models;
using NewsApp.Endpoints.UI.News.Services;

namespace NewsApp.Endpoints.UI.News.Components
{
    public partial class NewsList
    {
        private PagedData<NewsDto> pagedData;
        private readonly string error;
        PageQuery pageQuery = new();
        [Inject] INewsService NewsService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            pagedData = await NewsService.GetPagedListAsync(pageQuery);
        }

        private async Task SelectedPage(int page)
        {
            pageQuery.PageNumber = page;
            await LoadDataAsync();
        }
    }
}
