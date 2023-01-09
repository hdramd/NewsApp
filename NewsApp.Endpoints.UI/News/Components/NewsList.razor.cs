using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.News.Models;
using NewsApp.Endpoints.UI.News.Services;

namespace NewsApp.Endpoints.UI.News.Components
{
    public partial class NewsList
    {
        private PagedData<NewsDto> pagedData;
        private string ErrorMessage;
        PageQuery pageQuery = new();
        [Inject] INewsService NewsService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var result = await NewsService.GetPagedListAsync(pageQuery);
            if (result.Succeeded == false)
                ErrorMessage = result.ErrorMessage;
            else
                pagedData = result.Data;
        }

        private async Task SelectedPage(int page)
        {
            pageQuery.PageNumber = page;
            await LoadDataAsync();
        }

        private async Task Delete(long id)
        {
            var result = await NewsService.DeleteAsync(id);
            if (result.Succeeded == false)
                ErrorMessage = result.ErrorMessage;
            else
                await LoadDataAsync();
        }
    }
}
