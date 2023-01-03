using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.Models;

namespace NewsApp.Core.Contracts.News.Queries
{
	public interface INewsQueryRepository
	{
		public Task<NewsDto> Execute(GetNewsByBusinessIdQuery query);
	}
}
