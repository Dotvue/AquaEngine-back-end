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
    /// <summary>
    /// Creates a new instance of the <see cref="ProfileRepository"/> class.
    /// </summary>
    /// <param name="dni">
    /// The DNI to search for.
    /// </param>
    /// <returns>
    /// The profile with the given DNI, or null if no profile was found.
    /// </returns>
    public async Task<Profile?> FindProfileByDni(string dni)
    {
        return await Context.Set<Profile>().FirstOrDefaultAsync(profile => profile.Dni.Number == dni);
    }

    /// <summary>
    /// Finds a profile by its phone number.
    /// </summary>
    /// <param name="phoneNumber">
    /// The phone number to search for.
    /// </param>
    /// <returns>
    /// The profile with the given phone number, or null if no profile was found.
    /// </returns>
    public async Task<Profile?> FindProfileByPhoneNumber(string phoneNumber)
    {
        return await Context.Set<Profile>().FirstOrDefaultAsync(profile => profile.Phone.Number == phoneNumber);
    }

    /// <summary>
    /// Finds a profile by its user ID.
    /// </summary>
    /// <param name="userId">
    /// The user ID to search for.
    /// </param>
    /// <returns>
    /// The profile with the given user ID, or null if no profile was found.
    /// </returns>
    public async Task<Profile?> FindProfileByUserId(int userId)
    {
        return await Context.Set<Profile>().FirstOrDefaultAsync(
            profile => profile.UserIdentifier.Identifier == userId);
    }
}