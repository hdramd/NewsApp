using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.UI.Categories.Models;
using NewsApp.Endpoints.UI.Categories.Services;
using NewsApp.Endpoints.UI.News.Models;
using NewsApp.Endpoints.UI.News.Services;

namespace NewsApp.Endpoints.UI.News.Components
{
    public partial class NewsUpdate
    {
        [Parameter]
        public string NewsId { get; set; }
        List<CategoryDto> categories = new();
        UpdateNewsModel model = new();
        string[] SelectedCategories { get; set; } = Array.Empty<string>();
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] INewsService NewsService { get; set; }
        [Inject] ICategoryService CategoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (long.TryParse(NewsId, out long id) == false) return;
            var news = await NewsService.GetByIdAsync(id);
            MapToModel(news);

            var pagedData = await CategoryService.GetPagedListAsync();
            categories = pagedData.QueryResult;
        }

        private void MapToModel(NewsDto news)
        {
            model.Id = news.Id;
            model.Titr = news.Titr;
            SelectedCategories = news.Categories.Select(x => x.Id.ToString())
                .ToArray();
        }

        protected async Task Update()
        {
            model.CategoryIds = SelectedCategories.Select(x => Convert.ToInt64(x))
                .ToArray();
            await NewsService.UpdateAsync(model);
            NavigationManager.NavigateTo("/news");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/news");
        }
    }
}
