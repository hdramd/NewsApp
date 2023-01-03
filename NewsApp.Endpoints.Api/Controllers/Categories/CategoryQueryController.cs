using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Contracts.Categories.Queries.GetCategoryById;
using NewsApp.Core.Contracts.Categories.Queries.GetCategoryPagedList;
using NewsApp.Core.Contracts.Categories.Queries.Models;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace NewsApp.Endpoints.Api.Controllers.Categories
{
	[Route("api/Category")]
	public class CategoryQueryController : BaseController
	{
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(long id)
			=> await Query<GetCategoryByIdQuery, CategoryDto>(new GetCategoryByIdQuery { Id = id });

		[HttpGet(nameof(GetPagedList))]
		public async Task<IActionResult> GetPagedList(GetCategoryPagedListQuery query)
			=> await Query<GetCategoryPagedListQuery, PagedData<CategoryDto>>(query);
	}
}
