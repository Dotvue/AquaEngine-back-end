using AquaEngine.API.Profiles.Domain.Model.Aggregates;
using AquaEngine.API.Profiles.Domain.Model.Queries;

namespace AquaEngine.API.Profiles.Domain.Services;

/// <summary>
/// Profile query service: handles profile queries.
/// </summary>
public interface IProfileQueryService
{
    /// <summary>
    /// Handles the <see cref="GetProfileByUserIdQuery"/> query.
    /// </summary>
    /// <param name="query">
    /// Query to handle.
    /// </param>
    /// <returns>
    /// The profile with the specified user ID.
    /// </returns>
    Task<Profile?> Handle(GetProfileByUserIdQuery query);
}