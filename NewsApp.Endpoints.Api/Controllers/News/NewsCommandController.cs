using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Contracts.News.Commands.CreateNews;
using NewsApp.Core.Contracts.News.Commands.DeleteNews;
using NewsApp.Core.Contracts.News.Commands.UpdateNews;
using Zamin.EndPoints.Web.Controllers;

namespace NewsApp.Endpoints.Api.Controllers.News
{
	[Route("api/News")]
	[ApiController]
	public class NewsCommandController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateNewsCommand command)
		   => await Create<CreateNewsCommand, Guid>(command);

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] UpdateNewsCommand command)
		   => await Edit<UpdateNewsCommand, long>(command);

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(long id)
		   => await Delete(new DeleteNewsCommand { Id = id });
	}
}
