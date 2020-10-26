using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.Gym;
using Application.Features.Gym.Commands.CreateGym;
using Application.Features.Gym.Commands.DeleteGym;
using Application.Features.Gym.Commands.UpdateGym;
using Application.Features.Gym.Queries.GetAllGyms;
using Application.Features.Gym.Queries.GetGymById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Controllers.Helpers;

namespace WebApi.Controllers.Admin
{
    [Route("api/admin/gym")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class GymController : BaseApiController
    {
        [HttpGet("{id}")]
        [AllowAnonymous]
        [SwaggerResponse(200, "Successfully retrieved a gym", typeof(GymResponse))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var response = await Mediator.Send(new GetGymByIdQuery() {Id = id});
            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerResponse(200, "Successfully retrieved all gyms", typeof(IEnumerable<GymResponse>))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await Mediator.Send(new GetAllGymsQuery());
            return Ok(response);
        }

        [HttpPost]
        [SwaggerResponse(200, "Successfully created a gym", typeof(GymResponse))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> CreateAsync(CreateGymCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(200, "Successfully update a gym", typeof(GymResponse))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateGymCommand command)
        {
            command.Id = id;

            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "SuperAdmin")]
        [SwaggerResponse(200, "Successfully deleted a gym")]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteGymCommand() { Id = id });
            return Ok();
        }
    }
}