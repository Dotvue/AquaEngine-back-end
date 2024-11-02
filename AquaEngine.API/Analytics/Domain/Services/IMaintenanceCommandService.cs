using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Domain.Model.Entities;

namespace AquaEngine.API.Analytics.Domain.Services;

public interface IMaintenanceCommandService
{
    public Task<Maintenance?> Handle(CreateMaintenanceCommand command);
}