using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.UI.Categories.Models;
using NewsApp.Endpoints.UI.Categories.Services;

namespace NewsApp.Endpoints.UI.Categories.Components
{
    public partial class CategoryCreate
    {
        CreateCategoryModel model = new();
        string errorMessage = string.Empty;
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ICategoryService CategoryService { get; set; }


        protected async Task Create()
        {
            var result = await CategoryService.CreateAsync(model);
            if (result.Succeeded)
                NavigationManager.NavigateTo("/category");
            else
                errorMessage = result.ErrorMessage;
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/category");
        }
    }
}
