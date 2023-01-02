using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace NewsApp.Core.Contracts.News.Commands.CreateNews
{
    public class CreateNewsCommand : ICommand<Guid>
    {
        public string Titr { get; set; }
        public long[] CategoryIds { get; set; }
    }
}
