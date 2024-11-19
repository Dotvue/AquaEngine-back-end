using AquaEngine.API.Profiles.Domain.Model.Aggregates;
using AquaEngine.API.Profiles.Domain.Model.Commands;
using AquaEngine.API.Profiles.Domain.Repositories;
using AquaEngine.API.Profiles.Domain.Services;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Profiles.Application.Internal.CommandServices;

/// <summary>
/// Profile command service: manages the profile commands.
/// </summary>
/// <param name="profileRepository">
/// Profile repository.
/// </param>
/// <param name="unitOfWork">
/// Unit of work: manages the database transactions.
/// </param>
public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
    : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command, int userId)
    {
        if (profileRepository.ExistsByPhoneNumber(command.PhoneNumber))
            throw new ArgumentException("Phone number already exists.");
        
        if (profileRepository.ExistsByDni(command.DniNumber))
            throw new ArgumentException("DNI number already exists.");

        var profile = new Profile(command, userId);

        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception e)
        { 
            return null;
        }
    }
}