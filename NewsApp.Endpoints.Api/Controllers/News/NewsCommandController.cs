using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Contracts.News.Commands.CreateNews;
using Zamin.EndPoints.Web.Controllers;

namespace NewsApp.Endpoints.Api.Controllers.News
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsCommandController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateNewsCommand command)
           => await Create<CreateNewsCommand, Guid>(command);

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetBlogByBusinessId(GetBlogByBusinessIdQuery query)
        //    => await Query<GetBlogByBusinessIdQuery, BlogQr>(query);
    }
}
