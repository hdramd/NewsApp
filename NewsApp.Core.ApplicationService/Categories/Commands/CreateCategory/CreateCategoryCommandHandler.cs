using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;
using NewsApp.Core.Contracts.Categories.Commands.CreateCategory;
using NewsApp.Core.Domain.Categories.Entities;
using NewsApp.Core.Contracts.Categories.Commands;

namespace NewsApp.Core.ApplicationService.Categories.Commands.CreateCategory
{
	public class CreateCategoryCommandHandler : CommandHandler<CreateCategoryCommand, Guid>
	{
		private readonly ICategoryCommandRepository _categoryCommandRepository;
		public CreateCategoryCommandHandler(ZaminServices zaminServices,
			ICategoryCommandRepository categoryCommandRepository) : base(zaminServices)
		{
			_categoryCommandRepository = categoryCommandRepository;
		}

		public override async Task<CommandResult<Guid>> Handle(CreateCategoryCommand command)
		{
			var category = Category.Create(command.Name);
			await _categoryCommandRepository.InsertAsync(category);
			await _categoryCommandRepository.CommitAsync();
			return Ok(category.BusinessId.Value);
		}
	}
}
