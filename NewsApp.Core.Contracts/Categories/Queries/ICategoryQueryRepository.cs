using NewsApp.Core.Contracts.Categories.Queries.GetCategoryById;
using NewsApp.Core.Contracts.Categories.Queries.Models;

namespace NewsApp.Core.Contracts.Categories.Queries
{
    public interface ICategoryQueryRepository
    {
        Task<CategoryDto> GetByIdAsync(GetCategoryByIdQuery query);
    }
}
