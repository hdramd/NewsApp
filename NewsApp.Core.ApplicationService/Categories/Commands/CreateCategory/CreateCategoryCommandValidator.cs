using FluentValidation;
using NewsApp.Core.Contracts.Categories.Commands.CreateCategory;
using NewsApp.Core.Contracts.Categories.Queries;
using NewsApp.Core.Domain.Categories.Entities;
using Zamin.Extensions.Translations.Abstractions;

namespace NewsApp.Core.ApplicationService.Categories.Commands
{
	public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
	{
		private readonly ICategoryQueryRepository _categoryQueryRepository;
		public CreateCategoryCommandValidator(ITranslator translator,
			ICategoryQueryRepository categoryQueryRepository)
		{
			_categoryQueryRepository = categoryQueryRepository;

			RuleFor(c => c.Name)
				.NotNull().WithMessage(translator["Required", nameof(Category.Name)])
				.MinimumLength(2).WithMessage(translator["MinimumLength", nameof(Category.Name), "2"])
				.MaximumLength(200).WithMessage(translator["MaximumLength", nameof(Category.Name), "200"])
				.Must(NotExist).WithMessage(translator["Category with this name already exist."]);//TODO: Use MustAsync	
		}

		private bool NotExist(string arg)
		{
			var news = _categoryQueryRepository.GetAsync(x => x.Name.Equals(arg))
				.GetAwaiter().GetResult();

			return news == null;
		}
	}
}
