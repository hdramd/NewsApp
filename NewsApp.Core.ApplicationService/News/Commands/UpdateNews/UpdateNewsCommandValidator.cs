using FluentValidation;
using NewsApp.Core.Contracts.Categories.Queries;
using NewsApp.Core.Contracts.Images.Queries;
using NewsApp.Core.Contracts.News.Commands.UpdateNews;
using NewsApp.Core.Contracts.News.Queries;
using Zamin.Extensions.Translations.Abstractions;

namespace NewsApp.Core.ApplicationService.News.Commands.UpdateNews
{
    public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
    {
        private readonly INewsQueryRepository _newsQueryRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly IImageQueryRepository _imageQueryRepository;
        public UpdateNewsCommandValidator(ITranslator translator,
            INewsQueryRepository newsQueryRepository,
            ICategoryQueryRepository categoryQueryRepository,
            IImageQueryRepository imageQueryRepository)
        {
            _newsQueryRepository = newsQueryRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _imageQueryRepository = imageQueryRepository;

            RuleFor(x => x.Titr)
                .NotNull().NotEmpty().WithMessage(translator["Required", "Titr"])
                .MinimumLength(2).WithMessage(translator["MinimumLength", "Titr", "2"])
                .MaximumLength(200).WithMessage(translator["MaximumLength", "Titr", "200"]);

            RuleFor(x => x)
                .Must(NotExist).WithMessage(translator["News with this titr already exist."]);//TODO: Use MustAsync	

            RuleFor(x => x.CategoryIds)
                .NotNull().NotEmpty()
                .WithMessage(translator["Required", "CategoryIds"])
                .Must(BeExist).WithMessage(translator["Invalid category found!"]);

            RuleFor(x => x.ImageIds)
                .Must(BeExistImages).WithMessage(translator["Invalid image found!"])
                .When(x => x.ImageIds != null && x.ImageIds.Any());

        }

        private bool NotExist(UpdateNewsCommand arg)
        {
            var news = _newsQueryRepository.GetAsync(x => x.Titr.Equals(arg.Titr))
                .GetAwaiter().GetResult();

            return news == null || news.Id.Equals(arg.Id);
        }

        private bool BeExistImages(long[] arg)
        {
            var images = _imageQueryRepository.GetByIdAsync(arg.ToList())
                .GetAwaiter().GetResult();

            return arg.All(x => images.Select(c => c.Id).Contains(x));
        }

        private bool BeExist(long[] arg)
        {
            var categories = _categoryQueryRepository.GetByIdAsync(arg.ToList())
                .GetAwaiter().GetResult();

            return arg.All(x => categories.Select(c => c.Id).Contains(x));
        }
    }
}
