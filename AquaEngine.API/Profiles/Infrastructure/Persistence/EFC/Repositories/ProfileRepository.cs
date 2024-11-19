using Microsoft.EntityFrameworkCore;
using AquaEngine.API.Profiles.Domain.Repositories;
using AquaEngine.API.Profiles.Domain.Model.Aggregates;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace AquaEngine.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Profile repository: allows to find profiles by different criteria.
/// </summary>
/// <param name="context">
/// Database context.
/// </param>
public class ProfileRepository(AppDbContext context)
    : BaseRepository<Profile>(context), IProfileRepository
{
    /// <inheritdoc />
    public bool ExistsByDni(string dni)
    {
        return Context.Set<Profile>().Any(profile => profile.Dni.Number == dni);
    }

    /// <inheritdoc />
    public bool ExistsByPhoneNumber(string phoneNumber)
    {
        return Context.Set<Profile>().Any(profile => profile.Phone.Number == phoneNumber);
    }

    /// <inheritdoc />
    public bool ExistsByUserId(int userId)
    {
        return Context.Set<Profile>().Any(profile => profile.UserIdentifier.Identifier == userId);
    }

    /// <inheritdoc />
    public Task<Profile?> FindProfileByUserId(int userId)
    { 
        return Context.Set<Profile>().FirstOrDefaultAsync(profile => profile.UserIdentifier.Identifier == userId);
    }
}

