using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.Post;
using Application.Features.Post.Queries.GetAllPosts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Controllers.Helpers;

namespace WebApi.Controllers
{
    [Route("api/admin/posts")]
    [ApiController]
    public class PostsController : BaseApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [SwaggerResponse(200, "Successfully retrieved all posts", typeof(IEnumerable<PostResponse>))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await Mediator.Send(new GetAllPostsQuery());
            return Ok(response);
        }
    }
}