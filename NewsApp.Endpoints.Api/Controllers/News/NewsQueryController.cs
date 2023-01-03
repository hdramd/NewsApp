using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.EndPoints.Web.Controllers;

namespace NewsApp.Endpoints.Api.Controllers.News
{
	[Route("api/News")]
	public class NewsQueryController : BaseController
	{
		[HttpGet(nameof(GetByBusinessId))]
		public async Task<IActionResult> GetByBusinessId(GetNewsByBusinessIdQuery query) 
			=> await Query<GetNewsByBusinessIdQuery, NewsDto>(query);
	}
}
