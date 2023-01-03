using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Common;
using Zamin.Utilities;
using NewsApp.Core.Contracts.News.Commands.UpdateNews;
using NewsApp.Core.Contracts.News.Commands;

namespace NewsApp.Core.ApplicationService.News.Commands.UpdateNews
{
	public class UpdateNewsCommandHandler : CommandHandler<UpdateNewsCommand, long>
	{
		private readonly INewsCommandRepository _newsCommandRepository;
		public UpdateNewsCommandHandler(ZaminServices zaminServices,
			INewsCommandRepository newsCommandRepository)
			: base(zaminServices)
		{
			_newsCommandRepository = newsCommandRepository;
		}

		public override async Task<CommandResult<long>> Handle(UpdateNewsCommand command)
		{
			var news = await _newsCommandRepository.GetGraphAsync(command.Id);

			if (news is null)
				return await ResultAsync(command.Id, ApplicationServiceStatus.NotFound);

			news.Update(command.Titr, command.CategoryIds.ToList());
			await _newsCommandRepository.CommitAsync();
			return Ok(news.Id);
		}
	}
}
