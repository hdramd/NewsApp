using Microsoft.EntityFrameworkCore;
using NewsApp.Core.Contracts.Categories.Queries.Models;
using NewsApp.Core.Contracts.News.Queries;
using NewsApp.Core.Contracts.News.Queries.GetByCategoryIdPagedList;
using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.GetNewsPagedList;
using NewsApp.Core.Contracts.News.Queries.Models;
using NewsApp.Infra.Data.Sql.Queries.Common;
using System.Linq.Expressions;
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

            var newsImageQuery = _dbContext.NewsImageMappings
                .Join(imageQuery, x => x.ImageId, y => y.Id,
                (temp, image) => new
                {
                    temp.NewsId,
                    ImagePath = image.Path
                });

            var newsCategoryQuery = _dbContext.NewsCategoryMappings
                .Join(categoryQuery, x => x.CategoryId, y => y.Id,
                    (temp, cat) => new
                    {
                        temp.NewsId,
                        CategoryId = cat.Id,
                        CategoryName = cat.Name
                    });

            var finalQuery = from news in _dbContext.News
                             join image in newsImageQuery on news.Id equals image.NewsId into newsImages
                             from newsImage in newsImages.DefaultIfEmpty()
                             join category in newsCategoryQuery on news.Id equals category.NewsId into newsCategories
                             from newsCategory in newsCategories.DefaultIfEmpty()
                             select new
                             {
                                 news.Id,
                                 news.BusinessId,
                                 news.Titr,
                                 newsImage.ImagePath,
                                 newsCategory.CategoryId,
                                 newsCategory.CategoryName,
                             };

            var result = await finalQuery.Where(x => x.Id.Equals(query.Id))
                .ToListAsync();

            return result.GroupBy(x => x.Id)
                .Select(x => new NewsDto
                {
                    Id = x.Key,
                    BusinessId = x.First().BusinessId,
                    Titr = x.First().Titr,
                    Images = x.Select(x => x.ImagePath).ToArray(),
                    Categories = x.Select(c => new CategoryDto { Id = c.CategoryId, Name = c.CategoryName })
                    .ToList()
                }).FirstOrDefault();
        }

        public async Task<NewsDto> GetAsync(Expression<Func<NewsDto, bool>> predicate)
            => await _dbContext.News.Select(x => new NewsDto
            {
                Id = x.Id,
                BusinessId = x.BusinessId,
                Titr = x.Titr
            }).FirstOrDefaultAsync(predicate);

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

        public async Task<PagedData<NewsDto>> GetPagedListAsync(GetNewsPagedListQuery query)
        {
            var newsQuery = _dbContext.News;

            var categoryPagedQuery = newsQuery
                .OrderByDescending(x => x.Id)
                .Skip(query.SkipCount)
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
                QueryResult = await categoryPagedQuery.ToListAsync(),
                TotalCount = await newsQuery.CountAsync()
            };
        }
    }
}
