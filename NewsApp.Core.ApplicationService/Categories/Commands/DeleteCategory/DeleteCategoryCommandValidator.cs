using FluentValidation;
using NewsApp.Core.Contracts.Categories.Commands.DeleteCategory;
using Zamin.Extensions.Translations.Abstractions;

namespace NewsApp.Core.ApplicationService.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator(ITranslator translator)
        {
            RuleFor(x => x.Id)
                .NotNull().NotEmpty().WithMessage(translator["Required", "Id"])
                .Must(NotUsed).WithMessage(translator["This category used in news."]);
        }

        private bool NotUsed(long arg)
        {
            return false;
        }
    }
}
