using AquaEngine.API.Profiles.Domain.Model.Commands;
using AquaEngine.API.Profiles.Domain.Model.Queries;
using AquaEngine.API.Profiles.Domain.Services;

namespace AquaEngine.API.Profiles.Interfaces.ACL.Services;

/// <summary>
/// Represents the profiles context facade.
/// </summary>
/// <param name="profileCommandService">
/// The <see cref="IProfileCommandService"/> instance.
/// </param>
/// <param name="profileQueryService">
/// The <see cref="IProfileQueryService"/> instance.
/// </param>
public class ProfilesContextFacade(IProfileCommandService profileCommandService, 
    IProfileQueryService profileQueryService) : IProfilesContextFacade
{
    // <inheritdoc/>
    public async Task<int> CreateProfileAsync(string fullName, string email, string phoneNumber, string dniNumber, int userId)
    {
        var createProfileCommand = new CreateProfileCommand(fullName, email, phoneNumber, dniNumber);

        var profile = await profileCommandService.Handle(createProfileCommand, userId);
        
        return profile?.Id ?? 0;
    }

    // <inheritdoc/>
    public async Task<int> FetchProfileIdByUserId(int userId)
    {
        var getProfileByUserId = new GetProfileByUserIdQuery(userId);
        
        var profile = await profileQueryService.Handle(getProfileByUserId);
        
        return profile?.Id ?? 0;
    }
}