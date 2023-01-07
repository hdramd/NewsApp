using NewsApp.Core.Contracts.News.Commands;
using NewsApp.Core.Contracts.News.Commands.CreateNews;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;
using Entities = NewsApp.Core.Domain.News.Entities;

namespace NewsApp.Core.ApplicationService.News.Commands.CreateNews
{
	public class CreateNewsCommandHandler : CommandHandler<CreateNewsCommand, Guid>
	{
		private readonly INewsCommandRepository _newsCommandRepository;
		public CreateNewsCommandHandler(ZaminServices zaminServices,
			INewsCommandRepository newsCommandRepository) : base(zaminServices)
		{
			_newsCommandRepository = newsCommandRepository;
		}

		public override async Task<CommandResult<Guid>> Handle(CreateNewsCommand command)
		{
			Entities.News news = Entities.News.Create(command.Titr, 
				command.CategoryIds, command.ImageIds);
			await _newsCommandRepository.InsertAsync(news);
			await _newsCommandRepository.CommitAsync();
			return Ok(news.BusinessId.Value);
		}
	}
}
