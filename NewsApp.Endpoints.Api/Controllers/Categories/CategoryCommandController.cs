using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Contracts.Categories.Commands.CreateCategory;
using Zamin.EndPoints.Web.Controllers;

namespace NewsApp.Endpoints.Api.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryCommandController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
            => await Create<CreateCategoryCommand, Guid>(command);
    }
}
