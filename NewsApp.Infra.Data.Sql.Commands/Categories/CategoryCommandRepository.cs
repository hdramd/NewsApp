using NewsApp.Core.Contracts.Categories.Commands;
using NewsApp.Core.Domain.Categories.Entities;
using NewsApp.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace NewsApp.Infra.Data.Sql.Commands.Categories
{
    public class CategoryCommandRepository :
        BaseCommandRepository<Category, NewsAppCommandDbContext>,
        ICategoryCommandRepository
    {
        public CategoryCommandRepository(NewsAppCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
