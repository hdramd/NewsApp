using Microsoft.EntityFrameworkCore;
using NewsApp.Core.Contracts.Categories.Queries.Models;
using NewsApp.Core.Contracts.Images.Queries.Models;
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

		public async Task<NewsDto> GetByIdAsync(GetNewsByIdQuery query)
		{
			var categoryQuery = _dbContext.Categories;
			var imageQuery = _dbContext.Images;

			var newsQuery = _dbContext.News
				.Include(x => x.NewsCategoryMappings)
				.Include(x => x.NewsImageMappings)
				.Select(x => new
				{
					x.Id,
					x.BusinessId,
					x.Titr,
					CategoryIds = x.NewsCategoryMappings.Select(c => c.CategoryId),
					ImageIds = x.NewsImageMappings.Select(c => c.ImageId)
				});

			var finalQuery = from news in newsQuery
							 let categories = categoryQuery.Where(x => news.CategoryIds.Contains(x.Id)).ToList()
							 let images = imageQuery.Where(x => news.CategoryIds.Contains(x.Id)).ToList()
							 select new NewsDto
							 {
								 Id = news.Id,
								 BusinessId = news.BusinessId,
								 Titr = news.Titr,
								 Categories = categories.Select(x => new CategoryDto
								 {
									 Id = x.Id,
									 BusinessId = news.BusinessId,
									 Name = x.Name
								 }).ToList(),
								 Images = images.Select(x => new ImageDto
								 {
									 Id = x.Id,
									 BusinessId = x.BusinessId,
									 Path = x.Path
								 }).ToList()
							 };

			return await finalQuery.FirstOrDefaultAsync(c => c.Id.Equals(query.Id));
		}

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
