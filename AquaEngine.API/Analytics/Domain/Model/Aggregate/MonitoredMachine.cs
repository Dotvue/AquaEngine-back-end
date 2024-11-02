using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Domain.Model.Entities;
using AquaEngine.API.Analytics.Domain.Model.ValueObjects;

namespace AquaEngine.API.Analytics.Domain.Model.Aggregate;

public partial class MonitoredMachine
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string UrlToImage { get; private set; }
    public string Status { get; private set; }
    public long UserId{ get; private set; }

    public Maintenance maintenance  { get; internal set; }
    public int MaintenanceId { get; private set; }

    public MonitoredMachine(long userId, string name, string urlToImage, string status, int maintenanceId)
    {
        UserId = userId;
        Name = name;
        UrlToImage = urlToImage;
        Status = status;
        MaintenanceId = maintenanceId;
    }
    
    public MonitoredMachine(CreateMonitoredMachineCommand command)
    {
        UserId = command.UserId;
        Name = command.Name;
        UrlToImage = command.UrlToImage;
        Status = command.Status;
        MaintenanceId = command.MaintenanceId;
    }

    public void UpdateMonitoringStatus(UpdateMonitoringStatusCommand command)
    {
        Status = command.Status;
    }
    
    
}