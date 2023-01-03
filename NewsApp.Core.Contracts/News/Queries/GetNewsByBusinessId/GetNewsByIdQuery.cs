using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId
{
	public class GetNewsByIdQuery : IQuery<NewsDto>
	{
		public long Id { get; set; }
	}
}
