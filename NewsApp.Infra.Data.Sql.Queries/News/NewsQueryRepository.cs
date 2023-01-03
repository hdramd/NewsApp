using Microsoft.EntityFrameworkCore;
using NewsApp.Core.Contracts.News.Queries;
using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.Models;
using NewsApp.Infra.Data.Sql.Queries.Common;
using Zamin.Infra.Data.Sql.Queries;

namespace NewsApp.Infra.Data.Sql.Queries.News
{
	public class NewsQueryRepository : BaseQueryRepository<NewsAppQueryDbContext>, INewsQueryRepository
	{
		public NewsQueryRepository(NewsAppQueryDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<NewsDto> Execute(GetNewsByBusinessIdQuery query)
			=> await _dbContext.News.Select(c => new NewsDto()
			{
				Id = c.Id,
				BusinessId = c.BusinessId,
				Titr = c.Titr
			}).FirstOrDefaultAsync(c => c.BusinessId.Equals(query.BlogBusinessId));
	}
}
