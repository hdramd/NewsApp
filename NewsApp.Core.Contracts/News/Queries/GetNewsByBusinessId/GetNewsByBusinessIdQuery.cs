using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId
{
	public class GetNewsByBusinessIdQuery : IQuery<NewsDto>
	{
		public Guid BlogBusinessId { get; set; }
	}
}
