# Imagen base .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "BinaryConverterAPI.csproj"
RUN dotnet build "BinaryConverterAPI.csproj" -c Release -o /app/build

# Publicar
FROM build AS publish
RUN dotnet publish "BinaryConverterAPI.csproj" -c Release -o /app/publish

# Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BinaryConverterAPI.dll"]
