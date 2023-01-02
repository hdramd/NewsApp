using NewsApp.Core.Domain.Categories.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace NewsApp.Core.Contracts.Categories.Commands
{
    public interface ICategoryCommandRepository : ICommandRepository<Category>
    {
    }
}
