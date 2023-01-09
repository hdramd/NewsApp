using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;
using NewsApp.Endpoints.UI.Categories.Services;
using NewsApp.Endpoints.UI.News.Models;
using NewsApp.Endpoints.UI.News.Services;

namespace NewsApp.Endpoints.UI.News.Components
{
    public partial class NewsCreate
    {
        CreateNewsModel model = new();
        List<CategoryDto> categories = new();
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] INewsService NewsService { get; set; }
        [Inject] ICategoryService CategoryService { get; set; }

        public string[] SelectedCategories { get; set; } = Array.Empty<string>();

        protected override async Task OnInitializedAsync()
        {
            var pagedData = await CategoryService.GetPagedListAsync(new PageQuery { PageSize = 100 });
            categories = pagedData.QueryResult;
        }

        protected async Task Create()
        {
            model.CategoryIds = SelectedCategories.Select(x => Convert.ToInt64(x))
                .ToArray();
            await NewsService.CreateAsync(model);
            NavigationManager.NavigateTo("/news");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/news");
        }
    }
}
