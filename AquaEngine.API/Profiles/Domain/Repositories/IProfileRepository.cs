using AquaEngine.API.Profiles.Domain.Model.Aggregates;

namespace AquaEngine.API.Profiles.Domain.Repositories;

/// <summary>
/// Profile repository: allows to find profiles by different criteria.
/// </summary>
public interface IProfileRepository
{
    /// <summary>
    /// Finds a profile by its DNI.
    /// </summary>
    /// <param name="dni">
    /// The DNI to search for.
    /// </param>
    /// <returns>
    /// The profile with the given DNI, or null if no profile was found.
    /// </returns>
    Task<Profile?> FindProfileByDni(string dni);
    
    /// <summary>
    /// Finds a profile by its phone number.
    /// </summary>
    /// <param name="phoneNumber">
    /// The phone number to search for.
    /// </param>
    /// <returns>
    /// The profile with the given phone number, or null if no profile was found.
    /// </returns>
    Task<Profile?> FindProfileByPhoneNumber(string phoneNumber);
    
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