namespace AquaEngine.API.Analytics.Domain.Model.Commands;

public record CreateMaintenanceCommand(int MachineId,string Date, string Technician, string IssueType, string Description, string AdditionalInfo);
