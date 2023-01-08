using Microsoft.AspNetCore.Components;
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

        string selectedCategory;

        protected override async Task OnInitializedAsync()
        {
            var pagedData = await CategoryService.GetPagedListAsync();
            categories = pagedData.QueryResult;
        }

        protected async Task Create()
        {
            model.CategoryIds = model.CategoryIds ?? new long[1];
            model.CategoryIds[0] = Convert.ToInt64(selectedCategory);
            await NewsService.CreateAsync(model);
            NavigationManager.NavigateTo("/news");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/news");
        }
    }
}
