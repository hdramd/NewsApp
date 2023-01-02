using NewsApp.Core.Contracts.Categories.Queries.GetCategoryByBusinessId;
using NewsApp.Core.Contracts.Categories.Queries.Models;

namespace NewsApp.Core.Contracts.Categories.Queries
{
    public interface ICategoryQueryRepository
    {
        Task<CategoryDto> Execute(GetCategoryByBusinessIdQuery query);
    }
}
