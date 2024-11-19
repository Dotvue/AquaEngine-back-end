using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using AquaEngine.API.Profiles.Domain.Model.Commands;
using AquaEngine.API.Profiles.Domain.Model.ValueObjects;

namespace AquaEngine.API.Profiles.Domain.Model.Aggregates;

/// <summary>
/// Profile aggregate root: represents a user profile.
/// </summary>
/// <remarks>
/// This class represents the Profile aggregate root.
/// It contains the properties and methods to manage the profile information.
/// </remarks>
public partial class Profile
{
    public int Id { get; }
    
    public DniNumber Dni { get; }
    public string FullName { get; }
    public PhoneNumber Phone { get; }
    public EmailAddress Email { get; }
    public UserId UserIdentifier { get; }
    
    public string EmailAddress => Email.Address;

    public Profile()
    {
        FullName = string.Empty;
        Email = new EmailAddress();
        Phone = new PhoneNumber();
        Dni = new DniNumber();
        UserIdentifier = new UserId();
    }

    public Profile(CreateProfileCommand command, int userIdentifier)
    {
        FullName = command.FullName;
        Email = new EmailAddress(command.Email);
        Phone = new PhoneNumber(command.PhoneNumber);
        Dni = new DniNumber(command.DniNumber);
        UserIdentifier = new UserId(userIdentifier);
    }
}