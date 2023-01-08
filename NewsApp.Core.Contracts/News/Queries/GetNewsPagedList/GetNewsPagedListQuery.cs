using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace NewsApp.Core.Contracts.News.Queries.GetNewsPagedList
{
    public class GetNewsPagedListQuery : PageQuery<PagedData<NewsDto>>
    {
    }
}
