using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.UI.Categories.Models;
using NewsApp.Endpoints.UI.Categories.Services;

namespace NewsApp.Endpoints.UI.Categories.Components
{
    public partial class CategoryUpdate
    {
        [Parameter]
        public string CategoryId { get; set; }
        string ErrorMessage;
        UpdateCategoryModel model = new();
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ICategoryService CategoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (long.TryParse(CategoryId, out long id) == false) return;
            var result = await CategoryService.GetByIdAsync(id);
            if (result.Succeeded == false)
                ErrorMessage = result.ErrorMessage;
            else
                MapToModel(result.Data);
        }

        private void MapToModel(CategoryDto category)
        {
            model.Id = category.Id;
            model.Name = category.Name;
        }

        protected async Task Update()
        {
            var result = await CategoryService.UpdateAsync(model);
            if (result.Succeeded == false)
                ErrorMessage = result.ErrorMessage;
            else
                NavigationManager.NavigateTo("/category");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/category");
        }
    }
}
