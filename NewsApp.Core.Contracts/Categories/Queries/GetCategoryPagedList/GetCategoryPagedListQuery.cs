using NewsApp.Core.Contracts.Categories.Queries.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace NewsApp.Core.Contracts.Categories.Queries.GetCategoryPagedList
{
	public class GetCategoryPagedListQuery : PageQuery<PagedData<CategoryDto>>
	{
	}
}
