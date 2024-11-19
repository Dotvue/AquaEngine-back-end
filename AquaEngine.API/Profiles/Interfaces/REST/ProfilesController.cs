using System.Net.Mime;
using AquaEngine.API.Profiles.Domain.Model.Queries;
using AquaEngine.API.Profiles.Domain.Services;
using AquaEngine.API.Profiles.Interfaces.REST.Resources;
using AquaEngine.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AquaEngine.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Profile Endpoints.")]
public class ProfilesController(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService) : ControllerBase
{
    [HttpGet("{userId:int}")]
    [SwaggerOperation("Get Profile by User Id")]
    [SwaggerResponse(200, "Profile found.", typeof(ProfileResource))]
    [SwaggerResponse(404, "The profile was not found.")]
    public async Task<IActionResult> GetProfileByUserId(int userId)
    {
        var getProfileByUserId = new GetProfileByUserIdQuery(userId);

        var profile = await profileQueryService.Handle(getProfileByUserId);

        if (profile is null)
            return NotFound();

        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }
}