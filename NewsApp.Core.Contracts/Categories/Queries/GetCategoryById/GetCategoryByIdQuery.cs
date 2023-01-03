using NewsApp.Core.Contracts.Categories.Queries.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace NewsApp.Core.Contracts.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IQuery<CategoryDto>
    {
        public long Id { get; set; }
    }
}
