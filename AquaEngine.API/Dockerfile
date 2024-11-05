# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["AquaEngine.API/AquaEngine.API.csproj", "AquaEngine.API/"]
RUN dotnet restore "./AquaEngine.API/AquaEngine.API.csproj"

COPY . .
WORKDIR "/src/AquaEngine.API"
RUN dotnet build "./AquaEngine.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AquaEngine.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AquaEngine.API.dll"]
