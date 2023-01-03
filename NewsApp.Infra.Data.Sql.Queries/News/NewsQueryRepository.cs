using Microsoft.EntityFrameworkCore;
using NewsApp.Core.Contracts.News.Queries;
using NewsApp.Core.Contracts.News.Queries.GetByCategoryIdPagedList;
using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.Models;
using NewsApp.Infra.Data.Sql.Queries.Common;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace NewsApp.Infra.Data.Sql.Queries.News
{
	public class NewsQueryRepository : BaseQueryRepository<NewsAppQueryDbContext>, INewsQueryRepository
	{
		public NewsQueryRepository(NewsAppQueryDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<NewsDto> GetByIdAsync(GetNewsByBusinessIdQuery query)
			=> await _dbContext.News.Select(c => new NewsDto()
			{
				Id = c.Id,
				BusinessId = c.BusinessId,
				Titr = c.Titr
			}).FirstOrDefaultAsync(c => c.BusinessId.Equals(query.BlogBusinessId));

		public async Task<PagedData<NewsDto>> GetByCategoryIdPagedListAsync(GetByCategoryIdPagedListQuery query)
		{
			var newsQuery = _dbContext.NewsCategoryMappings
				.Include(x => x.News)
				.Where(x => x.CategoryId == query.CategoryId)
				.Select(x => x.News);

			var pagedNewsQuery = newsQuery.Skip(query.SkipCount)
				.Take(query.PageSize)
				.Select(x => new NewsDto
				{
					Id = x.Id,
					BusinessId = x.BusinessId,
					Titr = x.Titr
				});

			return new PagedData<NewsDto>
			{
				PageNumber = query.PageNumber,
				PageSize = query.PageSize,
				QueryResult = await pagedNewsQuery.ToListAsync(),
				TotalCount = await newsQuery.CountAsync()
			};
		}
	}
}
