using NewsApp.Core.Contracts.Categories.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;
using Zamin.Core.ApplicationServices.Commands;
using NewsApp.Core.Contracts.Categories.Commands.UpdateCategory;
using Zamin.Core.Contracts.ApplicationServices.Common;

namespace NewsApp.Core.ApplicationService.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : CommandHandler<UpdateCategoryCommand, long>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        public UpdateCategoryCommandHandler(ZaminServices zaminServices,
            ICategoryCommandRepository categoryCommandRepository) : base(zaminServices)
        {
            _categoryCommandRepository = categoryCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(UpdateCategoryCommand command)
        {
            var category = await _categoryCommandRepository.GetAsync(command.Id);

            if (category is null)
                return await ResultAsync(command.Id, ApplicationServiceStatus.NotFound);

            category.Update(command.Name);
            await _categoryCommandRepository.CommitAsync();
            return Ok(category.Id);
        }
    }
}
