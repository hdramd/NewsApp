using NewsApp.Core.Contracts.Categories.Queries.GetCategoryById;
using NewsApp.Core.Contracts.Categories.Queries.GetCategoryPagedList;
using NewsApp.Core.Contracts.Categories.Queries.Models;
using Zamin.Core.Contracts.Data.Queries;

namespace NewsApp.Core.Contracts.Categories.Queries
{
    public interface ICategoryQueryRepository
    {
        Task<CategoryDto> GetByIdAsync(GetCategoryByIdQuery query);
		Task<PagedData<CategoryDto>> GetPagedListAsync(GetCategoryPagedListQuery query);
	}
}
