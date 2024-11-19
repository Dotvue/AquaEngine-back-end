namespace AquaEngine.API.Profiles.Interfaces.REST.Resources;

public record ProfileResource(int userId, int profileId, 
    string FirstName, string LastName, string PhoneNumber, string Email, string DniNumber);