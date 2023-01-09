using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace NewsApp.Core.Contracts.News.Commands.CreateNews
{
    public class CreateNewsCommand : ICommand<long>
    {
        public string Titr { get; set; }
        public long[] CategoryIds { get; set; }
        public long[] ImageIds { get; set; }
    }
}
