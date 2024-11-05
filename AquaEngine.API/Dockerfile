# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Instalar dependencias adicionales
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar archivo de proyecto y restaurar dependencias
COPY ["AquaEngine.API/AquaEngine.API.csproj", "AquaEngine.API/"]
RUN dotnet restore "./AquaEngine.API/AquaEngine.API.csproj"

# Copiar el resto del código y compilar la aplicación
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

# Ejecutar la aplicación con dotnet
ENTRYPOINT ["dotnet", "AquaEngine.API.dll"]
