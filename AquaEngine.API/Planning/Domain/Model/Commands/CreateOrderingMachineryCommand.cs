using AquaEngine.API.Planning.Domain.Model.ValueObjects;

namespace AquaEngine.API.Planning.Domain.Model.Commands;

public record CreateOrderingMachineryCommand(int Id, string Name, string UrlToImage, string Status, EStockAspect EStockAspect);