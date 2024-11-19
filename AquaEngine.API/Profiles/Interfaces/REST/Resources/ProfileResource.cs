namespace AquaEngine.API.Profiles.Interfaces.REST.Resources;

public record ProfileResource(int userId, int profileId, 
    string FullName, string PhoneNumber, string Email, string DniNumber);