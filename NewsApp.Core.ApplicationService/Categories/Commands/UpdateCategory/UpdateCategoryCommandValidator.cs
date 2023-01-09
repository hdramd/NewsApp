using FluentValidation;
using NewsApp.Core.Contracts.Categories.Commands.UpdateCategory;
using NewsApp.Core.Contracts.Categories.Queries;
using NewsApp.Core.Domain.Categories.Entities;
using Zamin.Extensions.Translations.Abstractions;

namespace NewsApp.Core.ApplicationService.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        public UpdateCategoryCommandValidator(ITranslator translator,
            ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;

            RuleFor(c => c.Name)
                .NotNull().WithMessage(translator["Required", nameof(Category.Name)])
                .MinimumLength(2).WithMessage(translator["MinimumLength", nameof(Category.Name), "2"])
                .MaximumLength(200).WithMessage(translator["MaximumLength", nameof(Category.Name), "200"]);

            RuleFor(x => x)
                .Must(NotExist).WithMessage(translator["Category with this name already exist."]);//TODO: Use MustAsync	
        }

        private bool NotExist(UpdateCategoryCommand arg)
        {
            var category = _categoryQueryRepository.GetAsync(x => x.Name.Equals(arg.Name))
                .GetAwaiter().GetResult();

            return category == null || category.Id.Equals(arg.Id);
        }
    }
}
