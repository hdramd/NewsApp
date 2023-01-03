using NewsApp.Core.Contracts.Categories.Queries;
using NewsApp.Core.Contracts.Categories.Queries.GetCategoryPagedList;
using NewsApp.Core.Contracts.Categories.Queries.Models;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Utilities;

namespace NewsApp.Core.ApplicationService.Categories.Queries.GetCategoryPagedList
{
	public class GetCategoryPagedListQueryHandler : QueryHandler<GetCategoryPagedListQuery, PagedData<CategoryDto>>
	{
		private readonly ICategoryQueryRepository _categoryQueryRepository;
		public GetCategoryPagedListQueryHandler(ZaminServices zaminServices,
			ICategoryQueryRepository categoryQueryRepository) : base(zaminServices)
		{
			_categoryQueryRepository = categoryQueryRepository;
		}

		public override async Task<QueryResult<PagedData<CategoryDto>>> Handle(GetCategoryPagedListQuery query)
			=> Result(await _categoryQueryRepository.GetPagedListAsync(query));
	}
}
