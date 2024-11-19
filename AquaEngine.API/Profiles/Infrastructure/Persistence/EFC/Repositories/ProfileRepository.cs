using Microsoft.EntityFrameworkCore;
using AquaEngine.API.Profiles.Domain.Repositories;
using AquaEngine.API.Profiles.Domain.Model.Aggregates;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace AquaEngine.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context)
    : BaseRepository<Profile>(context), IProfileRepository
{
    public async Task<Profile?> FindProfileByDni(string dni)
    {
        return await Context.Set<Profile>().FirstOrDefaultAsync(profile => profile.Dni.Number == dni);
    }

    public async Task<Profile?> FindProfileByPhoneNumber(string phoneNumber)
    {
        return await Context.Set<Profile>().FirstOrDefaultAsync(profile => profile.Phone.Number == phoneNumber);
    }

    public async Task<Profile?> FindProfileByUserId(int userId)
    {
        return await Context.Set<Profile>().FirstOrDefaultAsync(
            profile => profile.UserIdentifier.Identifier == userId);
    }
}