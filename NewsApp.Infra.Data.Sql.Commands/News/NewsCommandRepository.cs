using NewsApp.Core.Contracts.News.Commands;
using NewsApp.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace NewsApp.Infra.Data.Sql.Commands.News
{
    public class NewsCommandRepository :
        BaseCommandRepository<Core.Domain.News.Entities.News, NewsAppCommandDbContext>,
        INewsCommandRepository
    {
        public NewsCommandRepository(NewsAppCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
