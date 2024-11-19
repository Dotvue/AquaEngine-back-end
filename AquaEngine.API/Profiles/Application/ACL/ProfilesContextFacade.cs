using AquaEngine.API.Profiles.Domain.Model.Commands;
using AquaEngine.API.Profiles.Domain.Model.Queries;
using AquaEngine.API.Profiles.Domain.Services;
using AquaEngine.API.Profiles.Interfaces.ACL;

namespace AquaEngine.API.Profiles.Application.ACL;

public class ProfilesContextFacade(IProfileCommandService profileCommandService, 
    IProfileQueryService profileQueryService) : IProfilesContextFacade
{
    public async Task<int> CreateProfileAsync(string firstName, 
        string lastName, string email, string phoneNumber, string dniNumber, int userId)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, email, phoneNumber, dniNumber);

        var profile = await profileCommandService.Handle(createProfileCommand, userId);
        
        return profile?.Id ?? 0;
    }

    public async Task<int> FetchProfileIdByUserId(int userId)
    {
        var getProfileByUserId = new GetProfileByUserIdQuery(userId);
        
        var profile = await profileQueryService.Handle(getProfileByUserId);
        
        return profile?.Id ?? 0;
    }
}