using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;
using NewsApp.Endpoints.UI.Categories.Services;

namespace NewsApp.Endpoints.UI.Categories.Components
{
    public partial class CategoryList
    {
        private PagedData<CategoryDto> pagedData;
        private string ErrorMessage;
        PageQuery pageQuery = new();
        [Inject] ICategoryService CategoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var result = await CategoryService.GetPagedListAsync(pageQuery);

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
    }
}
