using AquaEngine.API.IAM.Domain.Model.Queries;
using AquaEngine.API.IAM.Domain.Services;

namespace AquaEngine.API.IAM.Interfaces.ACL.Services;

public class UserContextFacade(IUserQueryService userQueryService)
    : IUserContextFacade
{
    public bool ExistsUserById(int userId)
    {
        try
        {
            var query = new GetUserByIdQuery(userId);
            var existingUser = userQueryService.Handle(query);
            
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}