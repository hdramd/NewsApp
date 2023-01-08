﻿using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.UI.Categories.Models;
using NewsApp.Endpoints.UI.Categories.Services;

namespace NewsApp.Endpoints.UI.Categories.Components
{
    public partial class CategoryUpdate
    {
        [Parameter]
        public string CategoryId { get; set; }

        UpdateCategoryModel model = new();
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ICategoryService CategoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (long.TryParse(CategoryId, out long id) == false) return;
            var category = await CategoryService.GetByIdAsync(id);
            MapToModel(category);
        }

        private void MapToModel(CategoryDto category)
        {
            model.Id = category.Id;
            model.Name = category.Name;
        }

        protected async Task Update()
        {
            await CategoryService.UpdateAsync(model);
            NavigationManager.NavigateTo("/category");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/category");
        }
    }
}