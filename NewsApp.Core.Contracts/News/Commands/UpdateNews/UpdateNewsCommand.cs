using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace NewsApp.Core.Contracts.News.Commands.UpdateNews
{
	public class UpdateNewsCommand : ICommand<long>
	{
		public long Id { get; set; }
		public string Titr { get; set; }
		public long[] CategoryIds { get; set; }
	}
}
