using NewsApp.Core.Contracts.News.Queries;
using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;

namespace NewsApp.Core.ApplicationService.News.Queries.GetNewsByBusinessId
{
	public class GetNewsByBusinessIdHandler : QueryHandler<GetNewsByBusinessIdQuery, NewsDto>
	{
		private readonly INewsQueryRepository _newsQueryRepository;

		public GetNewsByBusinessIdHandler(ZaminServices zaminServices,
										  INewsQueryRepository newsQueryRepository) : base(zaminServices)
		{
			_newsQueryRepository = newsQueryRepository;
		}

		public override async Task<QueryResult<NewsDto>> Handle(GetNewsByBusinessIdQuery query)
		{
			return Result(await _newsQueryRepository.Execute(query));
		}
	}
}
