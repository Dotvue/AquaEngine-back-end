using AquaEngine.API.Profiles.Domain.Model.Aggregates;
using AquaEngine.API.Profiles.Domain.Model.Commands;

namespace AquaEngine.API.Profiles.Domain.Services;

/// <summary>
/// Profile command service: handles profile commands.
/// </summary>
public interface IProfileCommandService
{
    /// <summary>
    /// Handles the create profile command.
    /// </summary>
    /// <param name="command">
    /// Create profile command.
    /// </param>
    /// <param name="userId">
    /// User identifier.
    /// </param>
    /// <returns>
    /// The created profile.
    /// </returns>
    Task<Profile?> Handle(CreateProfileCommand command, int userId);
}