using NewsApp.Core.Contracts.Categories.Commands;
using NewsApp.Core.Contracts.Categories.Commands.DeleteCategory;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace NewsApp.Core.ApplicationService.Categories.Commands.DeleteCategory
{
	public class DeleteCategoryCommandHandler : CommandHandler<DeleteCategoryCommand>
	{
		private readonly ICategoryCommandRepository _categoryCommandRepository;
		public DeleteCategoryCommandHandler(ZaminServices zaminServices,
			ICategoryCommandRepository categoryCommandRepository)
			: base(zaminServices)
		{
			_categoryCommandRepository = categoryCommandRepository;
		}

		public override async Task<CommandResult> Handle(DeleteCategoryCommand command)
		{
			_categoryCommandRepository.Delete(command.Id);
			await _categoryCommandRepository.CommitAsync();
			return await OkAsync();
		}
	}
}
