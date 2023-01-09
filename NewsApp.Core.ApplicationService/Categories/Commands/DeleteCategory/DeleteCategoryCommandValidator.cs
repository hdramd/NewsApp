using FluentValidation;
using NewsApp.Core.Contracts.Categories.Commands.DeleteCategory;
using NewsApp.Core.Contracts.News.Queries;
using NewsApp.Core.Contracts.News.Queries.GetByCategoryIdPagedList;
using Zamin.Extensions.Translations.Abstractions;

namespace NewsApp.Core.ApplicationService.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly INewsQueryRepository _newsQueryRepository;
        public DeleteCategoryCommandValidator(ITranslator translator,
            INewsQueryRepository newsQueryRepository)
        {
            _newsQueryRepository = newsQueryRepository;

            RuleFor(x => x.Id)
                .NotNull().NotEmpty().WithMessage(translator["Required", "Id"])
                .Must(NotUsed).WithMessage(translator["Delete failed. This category used in news."]);
        }

        private bool NotUsed(long arg)
        {
            var pagedData = _newsQueryRepository
                .GetByCategoryIdPagedListAsync(new GetByCategoryIdPagedListQuery { CategoryId = arg })
                .GetAwaiter().GetResult();

            return pagedData.QueryResult == null || !pagedData.QueryResult.Any();
        }
    }
}
