using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Contracts.Categories.Commands.CreateCategory;
using NewsApp.Core.Contracts.Categories.Commands.DeleteCategory;
using NewsApp.Core.Contracts.Categories.Commands.UpdateCategory;
using Zamin.EndPoints.Web.Controllers;

namespace NewsApp.Endpoints.Api.Controllers.Categories
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryCommandController : BaseController
    {
        [Obsolete]
        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
            => await Create<CreateCategoryCommand, Guid>(command);     
        
        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
            => await Create<CreateCategoryCommand, Guid>(command);  
        
        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryCommand command)
            => await Edit<UpdateCategoryCommand, long>(command); 
        
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryCommand command)
            => await Delete<DeleteCategoryCommand>(command);
    }
}
