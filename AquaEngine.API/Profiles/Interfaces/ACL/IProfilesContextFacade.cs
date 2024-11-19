namespace AquaEngine.API.Profiles.Interfaces.ACL;

/// <summary>
/// Profiles context facade interface: provides methods to interact with the profiles context.
/// </summary>
public interface IProfilesContextFacade
{
    /// <summary>
    /// Creates a new profile.
    /// </summary>
    /// <param name="firstName">
    /// First name.
    /// </param>
    /// <param name="lastName">
    /// Last name.
    /// </param>
    /// <param name="email">
    /// Email address.
    /// </param>
    /// <param name="phoneNumber">
    /// Phone number.
    /// </param>
    /// <param name="dniNumber">
    /// DNI number.
    /// </param>
    /// <returns>
    /// The profile identifier.
    /// </returns>
    /// <param name="userId">
    /// User identifier.
    /// </param>
    /// <returns>
    /// The profile identifier.
    /// </returns>
    Task<int> CreateProfileAsync(string firstName, 
        string lastName, string email, string phoneNumber, string dniNumber, int userId);
    
    /// <summary>
    /// Fetches the profile identifier by user identifier.
    /// </summary>
    /// <param name="userId">
    /// User identifier.
    /// </param>
    /// <returns>
    /// The profile identifier.
    /// </returns>
    Task<int> FetchProfileIdByUserId(int userId);
}