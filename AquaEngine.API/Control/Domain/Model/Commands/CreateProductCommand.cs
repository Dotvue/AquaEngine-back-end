namespace AquaEngine.API.Control.Domain.Model.Commands;

public record CreateProductCommand(string Name, string QuantityPerUnit, double UnitPrice, int Quantity, int UserId);