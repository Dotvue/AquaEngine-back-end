using AquaEngine.API.Profiles.Interfaces.ACL;

namespace AquaEngine.API.IAM.Application.Internal.OutboundServices;

/// <summary>
/// External profile service.
/// </summary>
/// <param name="profileContextFacade">
/// Profile context facade.
/// </param>
public class ExternalProfileService (IProfilesContextFacade profileContextFacade)
{
    /// <summary>
    /// Creates a new profile.
    /// </summary>
    /// <param name="userId">
    /// User identifier.
    /// </param>
    /// <param name="fullName">
    /// Full name.
    /// </param>
    /// <param name="phoneNumber">
    /// Phone number.
    /// </param>
    /// <param name="email">
    /// Email address.
    /// </param>
    /// <param name="dniNumber">
    /// DNI number.
    /// </param>
    /// <returns>
    /// The profile identifier.
    /// </returns>
    public async Task<int> CreateProfile(string fullName, string phoneNumber, string email, string dniNumber, int userId)
    {
        return await profileContextFacade.CreateProfileAsync(fullName, email, phoneNumber, dniNumber, userId);
    }
}