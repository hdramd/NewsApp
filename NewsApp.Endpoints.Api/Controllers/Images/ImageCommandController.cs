using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Contracts.Images.Commands.CreateImage;
using Zamin.EndPoints.Web.Controllers;

namespace NewsApp.Endpoints.Api.Controllers.Images
{
    [Route("api/Image")]
    [ApiController]
    public class ImageCommandController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateImageCommand command)
           => await Create<CreateImageCommand, Guid>(command);

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(long id)
        //   => await Delete(new DeleteNewsCommand { Id = id });
    }
}
