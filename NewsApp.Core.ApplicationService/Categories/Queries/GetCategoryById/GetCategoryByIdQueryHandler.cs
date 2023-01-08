using NewsApp.Core.Contracts.Categories.Queries;
using NewsApp.Core.Contracts.Categories.Queries.GetCategoryById;
using NewsApp.Core.Contracts.Categories.Queries.Models;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;

namespace NewsApp.Core.ApplicationService.Categories.Queries.GetCategoryById
{
	public class GetCategoryByIdQueryHandler : QueryHandler<GetCategoryByIdQuery, CategoryDto>
	{
		private readonly ICategoryQueryRepository _categoryQueryRepository;
		public GetCategoryByIdQueryHandler(ZaminServices zaminServices,
			ICategoryQueryRepository categoryQueryRepository) : base(zaminServices)
		{
			_categoryQueryRepository = categoryQueryRepository;
		}

		public override async Task<QueryResult<CategoryDto>> Handle(GetCategoryByIdQuery query)
			=> Result(await _categoryQueryRepository.GetAsync(x => x.Id.Equals(query.Id)));
	}
}
