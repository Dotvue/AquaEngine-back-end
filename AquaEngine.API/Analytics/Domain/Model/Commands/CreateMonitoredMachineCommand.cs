﻿namespace AquaEngine.API.Analytics.Domain.Model.Commands;

public record CreateMonitoredMachineCommand(long UserId,string Name,string UrlToImage, string Status, int MaintenanceId);