using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.Shared.Models;
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
        string ErrorMessage;
        string[] SelectedCategories { get; set; } = Array.Empty<string>();
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] INewsService NewsService { get; set; }
        [Inject] ICategoryService CategoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (long.TryParse(NewsId, out long id) == false) return;
            var newsResult = await NewsService.GetByIdAsync(id);
            if (newsResult.Succeeded == false)
                ErrorMessage = newsResult.ErrorMessage;
            else
                MapToModel(newsResult.Data);

            var result = await CategoryService.GetPagedListAsync(new PageQuery { PageSize = 1000 });
            if (result.Succeeded == false)
                ErrorMessage = result.ErrorMessage;
            else
                categories = result.Data.QueryResult;
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
            var result = await NewsService.UpdateAsync(model);
            if (result.Succeeded == false)
                ErrorMessage = result.ErrorMessage;
            else
                NavigationManager.NavigateTo("/news");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/news");
        }
    }
}
