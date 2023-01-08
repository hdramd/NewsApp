using NewsApp.Core.Contracts.Categories.Queries.GetCategoryById;
using NewsApp.Core.Contracts.Categories.Queries.GetCategoryPagedList;
using NewsApp.Core.Contracts.Categories.Queries.Models;
using System.Linq.Expressions;
using Zamin.Core.Contracts.Data.Queries;

namespace NewsApp.Core.Contracts.Categories.Queries
{
    public interface ICategoryQueryRepository
    {
		Task<CategoryDto> GetAsync(Expression<Func<CategoryDto, bool>> predicate);
		Task<List<CategoryDto>> GetByIdAsync(List<long> ids);
		Task<PagedData<CategoryDto>> GetPagedListAsync(GetCategoryPagedListQuery query);
	}
}
