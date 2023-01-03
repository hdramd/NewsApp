﻿using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Contracts.News.Queries.GetByCategoryIdPagedList;
using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace NewsApp.Endpoints.Api.Controllers.News
{
	[Route("api/News")]
	public class NewsQueryController : BaseController
	{
		[HttpGet(nameof(GetByBusinessId))]
		public async Task<IActionResult> GetByBusinessId(GetNewsByBusinessIdQuery query)
			=> await Query<GetNewsByBusinessIdQuery, NewsDto>(query);

		[HttpGet(nameof(GetByCategoryIdPagedList))]
		public async Task<IActionResult> GetByCategoryIdPagedList(GetByCategoryIdPagedListQuery query)
			=> await Query<GetByCategoryIdPagedListQuery, PagedData<NewsDto>>(query);
	}
}
