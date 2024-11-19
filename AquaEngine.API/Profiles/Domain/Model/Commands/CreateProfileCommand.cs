namespace AquaEngine.API.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string FirstName, string LastName, string Email, string PhoneNumber, string DniNumber);