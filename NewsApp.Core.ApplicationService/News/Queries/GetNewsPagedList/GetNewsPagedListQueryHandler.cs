using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;
using NewsApp.Core.Contracts.News.Queries;
using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Core.ApplicationServices.Queries;
using NewsApp.Core.Contracts.News.Queries.GetNewsPagedList;

namespace NewsApp.Core.ApplicationService.News.Queries.GetNewsPagedList
{
    public class GetNewsPagedListQueryHandler : QueryHandler<GetNewsPagedListQuery, PagedData<NewsDto>>
    {
        private readonly INewsQueryRepository _newsQueryRepository;
        public GetNewsPagedListQueryHandler(ZaminServices zaminServices,
            INewsQueryRepository newsQueryRepository) : base(zaminServices)
        {
            _newsQueryRepository = newsQueryRepository;
        }

        public override async Task<QueryResult<PagedData<NewsDto>>> Handle(GetNewsPagedListQuery query)
            => Result(await _newsQueryRepository.GetPagedListAsync(query));
    }
}
