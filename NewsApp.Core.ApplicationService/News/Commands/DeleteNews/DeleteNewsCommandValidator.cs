using FluentValidation;
using NewsApp.Core.Contracts.News.Commands.DeleteNews;
using Zamin.Extensions.Translations.Abstractions;

namespace NewsApp.Core.ApplicationService.News.Commands.DeleteNews
{
	public class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsCommand>
	{
		public DeleteNewsCommandValidator(ITranslator translator)
		{
			RuleFor(x => x.Id)
				.NotNull().NotEmpty().WithMessage(translator["Required", "Id"]);	
		}
	}
}
