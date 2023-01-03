using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace NewsApp.Core.Contracts.News.Commands.DeleteNews
{
	public class DeleteNewsCommand : ICommand<long>
	{
		public long Id { get; set; }
	}
}
