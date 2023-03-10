using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Contracts.Categories.Commands.CreateCategory;
using NewsApp.Core.Contracts.Categories.Commands.DeleteCategory;
using NewsApp.Core.Contracts.Categories.Commands.UpdateCategory;
using Zamin.EndPoints.Web.Controllers;

namespace NewsApp.Endpoints.Api.Controllers.Categories
{
	[Route("api/Category")]
	public class CategoryCommandController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Post([FromBody]CreateCategoryCommand command)
			=> await Create<CreateCategoryCommand, long>(command);

		[Obsolete]
		[HttpPost(nameof(Create))]
		public async Task<IActionResult> Create([FromBody]CreateCategoryCommand command)
			=> await Create<CreateCategoryCommand, long>(command);

		[HttpPut]
		public async Task<IActionResult> Put([FromBody]UpdateCategoryCommand command)
			=> await Edit<UpdateCategoryCommand, long>(command);

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(long id)
			=> await Delete(new DeleteCategoryCommand { Id = id });
	}
}
