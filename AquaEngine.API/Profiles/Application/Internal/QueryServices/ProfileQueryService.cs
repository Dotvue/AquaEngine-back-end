using AquaEngine.API.Profiles.Domain.Model.Aggregates;
using AquaEngine.API.Profiles.Domain.Model.Queries;
using AquaEngine.API.Profiles.Domain.Repositories;
using AquaEngine.API.Profiles.Domain.Services;

namespace AquaEngine.API.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    public Task<Profile?> Handle(GetProfileByUserIdQuery query)
    {
        return profileRepository.FindProfileByUserId(query.UserId);
    }
}