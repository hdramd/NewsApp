using NewsApp.Core.Contracts.News.Queries;
using NewsApp.Core.Contracts.News.Queries.GetByCategoryIdPagedList;
using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Utilities;

namespace NewsApp.Core.ApplicationService.News.Queries.GetByCategoryIdPagedList
{
	public class GetByCategoryIdPagedListHandler : QueryHandler<GetByCategoryIdPagedListQuery, PagedData<NewsDto>>
	{
		private readonly INewsQueryRepository _newsQueryRepository;
		public GetByCategoryIdPagedListHandler(ZaminServices zaminServices,
			INewsQueryRepository newsQueryRepository) : base(zaminServices)
		{
			_newsQueryRepository = newsQueryRepository;
		}

		public override async Task<QueryResult<PagedData<NewsDto>>> Handle(GetByCategoryIdPagedListQuery query)
			=> Result(await _newsQueryRepository.GetByCategoryIdPagedListAsync(query));

	}
}
