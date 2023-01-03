using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace NewsApp.Core.Contracts.News.Queries.GetByCategoryIdPagedList
{
	public class GetByCategoryIdPagedListQuery : PageQuery<PagedData<NewsDto>>
	{
		public long CategoryId { get; set; }
	}
}
