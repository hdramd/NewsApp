using Zamin.Core.Contracts.Data.Commands;

namespace NewsApp.Core.Contracts.News.Commands
{
    public interface INewsCommandRepository : ICommandRepository<Domain.News.Entities.News>
    {
    }
}
