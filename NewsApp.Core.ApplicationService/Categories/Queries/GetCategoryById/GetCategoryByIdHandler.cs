using NewsApp.Core.Contracts.Categories.Queries;
using NewsApp.Core.Contracts.Categories.Queries.GetCategoryById;
using NewsApp.Core.Contracts.Categories.Queries.Models;
using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;

namespace NewsApp.Core.ApplicationService.Categories.Queries.GetCategoryById
{
	public class GetCategoryByIdHandler : QueryHandler<GetCategoryByIdQuery, CategoryDto>
	{
		private readonly ICategoryQueryRepository _categoryQueryRepository;
		public GetCategoryByIdHandler(ZaminServices zaminServices,
			ICategoryQueryRepository categoryQueryRepository) : base(zaminServices)
		{
			_categoryQueryRepository = categoryQueryRepository;
		}

		public override async Task<QueryResult<CategoryDto>> Handle(GetCategoryByIdQuery query)
			=> Result(await _categoryQueryRepository.GetByIdAsync(query));
	}
}
