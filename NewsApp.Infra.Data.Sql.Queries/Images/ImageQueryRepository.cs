using Microsoft.EntityFrameworkCore;
using NewsApp.Core.Contracts.Images.Queries;
using NewsApp.Core.Contracts.Images.Queries.Models;
using NewsApp.Infra.Data.Sql.Queries.Common;
using Zamin.Infra.Data.Sql.Queries;

namespace NewsApp.Infra.Data.Sql.Queries.Images
{
	public class ImageQueryRepository : BaseQueryRepository<NewsAppQueryDbContext>, IImageQueryRepository
	{
		public ImageQueryRepository(NewsAppQueryDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<List<ImageDto>> GetByIdAsync(List<long> ids)
			=> await _dbContext.Images
				.Where(x => ids.Contains(x.Id))
				.Select(x => new ImageDto
				{
					Id = x.Id,
					BusinessId = x.BusinessId,
					Path = x.Path
				}).ToListAsync();
	}
}
