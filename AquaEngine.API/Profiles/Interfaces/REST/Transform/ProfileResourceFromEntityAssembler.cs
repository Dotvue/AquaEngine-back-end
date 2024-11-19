using AquaEngine.API.Profiles.Domain.Model.Aggregates;
using AquaEngine.API.Profiles.Interfaces.REST.Resources;

namespace AquaEngine.API.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.UserIdentifier.Identifier,
            entity.Name.Name, entity.Name.LastName, entity.Phone.Number, entity.EmailAddress, entity.Dni.Number);
    }
}