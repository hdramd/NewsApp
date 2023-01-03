using NewsApp.Core.Contracts.News.Commands;
using NewsApp.Core.Contracts.News.Commands.DeleteNews;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace NewsApp.Core.ApplicationService.News.Commands.DeleteNews
{
	public class DeleteNewsCommandHandler : CommandHandler<DeleteNewsCommand>
	{
		private readonly INewsCommandRepository _newsCommandRepository;
		public DeleteNewsCommandHandler(ZaminServices zaminServices,
			INewsCommandRepository newsCommandRepository) : base(zaminServices)
		{
			_newsCommandRepository = newsCommandRepository;
		}

		public override async Task<CommandResult> Handle(DeleteNewsCommand command)
		{
			_newsCommandRepository.Delete(command.Id);
			await _newsCommandRepository.CommitAsync();
			return await OkAsync();
		}
	}
}
