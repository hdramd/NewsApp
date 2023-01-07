using FluentValidation;
using NewsApp.Core.Contracts.Categories.Queries;
using NewsApp.Core.Contracts.News.Commands.DeleteNews;
using Zamin.Extensions.Translations.Abstractions;

namespace NewsApp.Core.ApplicationService.News.Commands.DeleteNews
{
	public class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsCommand>
	{
		private readonly ICategoryQueryRepository _categoryQueryRepository;
		public DeleteNewsCommandValidator(ITranslator translator, 
			ICategoryQueryRepository categoryQueryRepository)
		{
			_categoryQueryRepository= categoryQueryRepository;

			RuleFor(x => x.Id)
				.NotNull().NotEmpty().WithMessage(translator["Required", "Id"])
				.Must(NotUsed).WithMessage(translator["This category is used in atleast one news."]);
				
		}

		private bool NotUsed(long id)
		{
			return false;
		}
	}
}
