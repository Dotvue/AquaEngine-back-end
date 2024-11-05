# Imagen base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Imagen de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AquaEngine.API.csproj", "./"]
RUN dotnet restore "AquaEngine.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AquaEngine.API.csproj" -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish "AquaEngine.API.csproj" -c Release -o /app/publish

# Configuración final de imagen
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AquaEngine.API.dll"]
