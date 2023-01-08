using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Contracts.News.Queries.GetByCategoryIdPagedList;
using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.GetNewsPagedList;
using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace NewsApp.Endpoints.Api.Controllers.News
{
	[Route("api/News")]
	public class NewsQueryController : BaseController
	{
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(long id)
			=> await Query<GetNewsByIdQuery, NewsDto>(new GetNewsByIdQuery { Id = id });

		[HttpGet(nameof(GetByCategoryIdPagedList))]
		public async Task<IActionResult> GetByCategoryIdPagedList(GetByCategoryIdPagedListQuery query)
			=> await Query<GetByCategoryIdPagedListQuery, PagedData<NewsDto>>(query);

        [HttpGet(nameof(GetPagedList))]
        public async Task<IActionResult> GetPagedList(GetNewsPagedListQuery query)
			=> await Query<GetNewsPagedListQuery, PagedData<NewsDto>>(query);
    }
}
