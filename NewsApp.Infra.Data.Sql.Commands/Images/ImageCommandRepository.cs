using NewsApp.Core.Contracts.Images.Commands;
using NewsApp.Core.Domain.Images.Entities;
using NewsApp.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace NewsApp.Infra.Data.Sql.Commands.Images
{
	public class ImageCommandRepository :
		BaseCommandRepository<Image, NewsAppCommandDbContext>,
		IImageCommandRepository
	{
		public ImageCommandRepository(NewsAppCommandDbContext dbContext) : base(dbContext)
		{
		}
	}
}
