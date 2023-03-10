using Microsoft.EntityFrameworkCore;
using NewsApp.Core.Contracts.Categories.Queries;
using NewsApp.Core.Contracts.Categories.Queries.GetCategoryPagedList;
using NewsApp.Core.Contracts.Categories.Queries.Models;
using NewsApp.Infra.Data.Sql.Queries.Common;
using System.Linq.Expressions;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace NewsApp.Infra.Data.Sql.Queries.Categories
{
    public class CategoryQueryRepository : BaseQueryRepository<NewsAppQueryDbContext>, ICategoryQueryRepository
    {
        public CategoryQueryRepository(NewsAppQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CategoryDto> GetAsync(Expression<Func<CategoryDto, bool>> predicate)
            => await _dbContext.Categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                BusinessId = x.BusinessId,
                Name = x.Name
            }).FirstOrDefaultAsync(predicate);

        public async Task<List<CategoryDto>> GetByIdAsync(List<long> ids)
            => await _dbContext.Categories
                .Where(x => ids.Contains(x.Id))
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    BusinessId = x.BusinessId,
                    Name = x.Name
                }).ToListAsync();

        public async Task<PagedData<CategoryDto>> GetPagedListAsync(GetCategoryPagedListQuery query)
        {
            var categoryQuery = _dbContext.Categories;

            var categoryPagedQuery = categoryQuery
                .OrderByDescending(x => x.Id)
                .Skip(query.SkipCount)
                .Take(query.PageSize)
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    BusinessId = x.BusinessId,
                    Name = x.Name
                });

            return new PagedData<CategoryDto>
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                QueryResult = await categoryPagedQuery.ToListAsync(),
                TotalCount = await categoryQuery.CountAsync()
            };
        }
    }
}
