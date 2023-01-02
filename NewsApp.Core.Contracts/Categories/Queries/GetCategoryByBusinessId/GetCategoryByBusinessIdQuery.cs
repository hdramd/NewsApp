using NewsApp.Core.Contracts.Categories.Queries.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace NewsApp.Core.Contracts.Categories.Queries.GetCategoryByBusinessId
{
    public class GetCategoryByBusinessIdQuery : IQuery<CategoryDto>
    {
        public Guid CategoryBusinessId { get; set; }
    }
}
