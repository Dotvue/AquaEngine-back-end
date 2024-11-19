namespace AquaEngine.API.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string FullName, string Email, string PhoneNumber, string DniNumber);