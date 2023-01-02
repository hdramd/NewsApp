//using FluentValidation;
//using NewsApp.Core.Contracts.Categories.Commands.CreateCategory;
//using NewsApp.Core.Domain.Categories.Entities;
//using Zamin.Extensions.Translations.Abstractions;

//namespace NewsApp.Core.ApplicationService.Categories.Commands
//{
//    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
//    {
//        public CreateCategoryCommandValidator(ITranslator translator)
//        {
//            RuleFor(c => c.Name)
//                .NotNull().WithMessage(translator["Required", nameof(Category.Name)])
//                .MinimumLength(10).WithMessage(translator["MinimumLength", nameof(Category.Name), "2"])
//                .MaximumLength(100).WithMessage(translator["MaximumLength", nameof(Category.Name), "200"]);
//        }
//    }
//}
