namespace AquaEngine.API.IAM.Interfaces.ACL;

/// <summary>
/// User context facade.
/// </summary>
public interface IUserContextFacade
{
    /// <summary>
    /// Checks if a user exists by its identifier.
    /// </summary>
    /// <param name="userId">
    /// User identifier.
    /// </param>
    /// <returns>
    /// True if the user exists, false otherwise.
    /// </returns>
    bool ExistsUserById(int userId);
}