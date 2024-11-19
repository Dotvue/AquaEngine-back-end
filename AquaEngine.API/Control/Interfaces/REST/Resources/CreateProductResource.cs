namespace AquaEngine.API.Control.Interfaces.REST.Resources;

public record CreateProductResource(string Name, string QuantityPerUnit, double UnitPrice, int Quantity, int UserId);