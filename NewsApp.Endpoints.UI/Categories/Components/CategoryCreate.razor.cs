using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.UI.Categories.Models;
using NewsApp.Endpoints.UI.Categories.Services;

namespace NewsApp.Endpoints.UI.Categories.Components
{
    public partial class CategoryCreate
    {
        CreateCategoryModel model = new();
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ICategoryService CategoryService { get; set; }


        protected async Task Create()
        {
            await CategoryService.CreateAsync(model);
            NavigationManager.NavigateTo("/category");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/category");
        }
    }
}
