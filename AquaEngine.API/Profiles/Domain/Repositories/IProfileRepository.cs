using AquaEngine.API.Profiles.Domain.Model.Aggregates;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Profiles.Domain.Repositories;

/// <summary>
/// Profile repository: allows to find profiles by different criteria.
/// </summary>
public interface IProfileRepository : IBaseRepository<Profile>
{
    /// <summary>
    /// Checks if a profile with the given DNI exists.
    /// </summary>
    /// <param name="dni">
    /// The DNI to search for.
    /// </param>
    /// <returns>
    /// True if a profile with the given DNI exists, false otherwise.
    /// </returns>
    bool ExistsByDni(string dni);
    
    /// <summary>
    /// Checks if a profile with the given email address exists.
    /// </summary>
    /// <param name="phoneNumber">
    /// The email address to search for.
    /// </param>
    /// <returns>
    /// True if a profile with the given email address exists, false otherwise.
    /// </returns>
    bool ExistsByPhoneNumber(string phoneNumber);
    
    /// <summary>
    /// Checks if a profile with the given user ID exists.
    /// </summary>
    /// <param name="userId">
    /// The user ID to search for.
    /// </param>
    /// <returns>
    /// True if a profile with the given user ID exists, false otherwise.
    /// </returns>
    bool ExistsByUserId(int userId);
    
    /// <summary>
    /// Finds a profile by its user ID.
    /// </summary>
    /// <param name="userId">
    /// The user ID to search for.
    /// </param>
    /// <returns>
    /// The profile with the given user ID, or null if no profile was found.
    /// </returns>
    Task<Profile?> FindProfileByUserId(int userId);
}