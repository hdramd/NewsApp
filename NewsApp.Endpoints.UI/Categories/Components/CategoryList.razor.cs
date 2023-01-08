using Microsoft.AspNetCore.Components;
using NewsApp.Endpoints.Shared.Models;
using NewsApp.Endpoints.UI.Categories.Models;

namespace NewsApp.Endpoints.UI.Categories.Components
{
    public partial class CategoryList
    {
        private PagedData<CategoryDto> pagedData;
        private readonly string error;


        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            pagedData = await EmployeeService.GetPagedListAsync();
        }
    }
}
