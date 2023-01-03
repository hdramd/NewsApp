using Microsoft.EntityFrameworkCore;
using NewsApp.Core.Contracts.Categories.Queries;
using NewsApp.Core.Contracts.Categories.Queries.GetCategoryById;
using NewsApp.Core.Contracts.Categories.Queries.Models;
using NewsApp.Infra.Data.Sql.Queries.Common;
using Zamin.Infra.Data.Sql.Queries;

namespace NewsApp.Infra.Data.Sql.Queries.Categories
{
	public class CategoryQueryRepository : BaseQueryRepository<NewsAppQueryDbContext>, ICategoryQueryRepository
	{
		public CategoryQueryRepository(NewsAppQueryDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<CategoryDto> GetByIdAsync(GetCategoryByIdQuery query)
			=> await _dbContext.Categories.Select(c => new CategoryDto()
			{
				Id = c.Id,
				BusinessId = c.BusinessId,
				Name = c.Name
			}).FirstOrDefaultAsync(c => c.Id.Equals(query.Id));
	}
}
