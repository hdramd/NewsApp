//using FluentValidation;
//using NewsApp.Core.Contracts.Categories.Queries;
//using NewsApp.Core.Contracts.News.Commands.CreateNews;
//using Zamin.Extensions.Translations.Abstractions;

//namespace NewsApp.Core.ApplicationService.News.Commands
//{
//    public class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
//    {
//        private readonly ICategoryQueryRepository _categoryQueryRepository;
//        public CreateNewsCommandValidator(ITranslator translator,
//            ICategoryQueryRepository categoryQueryRepository)
//        {
//            _categoryQueryRepository = categoryQueryRepository;

//            RuleFor(c => c.Titr)
//                .NotNull().WithMessage(translator["Required", "Titr"])
//                .MinimumLength(10).WithMessage(translator["MinimumLength", "Titr", "2"])
//                .MaximumLength(100).WithMessage(translator["MaximumLength", "Titr", "200"]);

//            RuleFor(c => c.CategoryIds)
//                .NotNull().NotEmpty()
//                .WithMessage(translator["Required", "CategoryIds"]);
                
//            //.MustAsync(BeExistAsync).WithMessage(translator["Category not found."]);
//        }

//        private Task<bool> BeExistAsync(long arg1, CancellationToken arg2)
//        {
//            //_categoryQueryRepository.Execute(new GetCategoryByBusinessIdQuery { });
//            return Task.FromResult(true);
//        }
//    }
//}
