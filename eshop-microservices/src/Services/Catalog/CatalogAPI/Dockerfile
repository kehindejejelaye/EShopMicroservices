#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Catalog/CatalogAPI/CatalogAPI.csproj", "src/Services/Catalog/CatalogAPI/"]
COPY ["src/BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "src/BuildingBlocks/BuildingBlocks/"]
RUN dotnet restore "./src/Services/Catalog/CatalogAPI/CatalogAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/Catalog/CatalogAPI"
RUN dotnet build "./CatalogAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CatalogAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Install OpenSSL and create a development certificate
RUN apt-get update && apt-get install -y openssl && \
    dotnet dev-certs https -ep /https/aspnetapp.pfx -p P@ssw0rd && \
    dotnet dev-certs https --trust

COPY --from=publish /app/publish .

ENV ASPNETCORE_Kestrel__Certificates__Default__Password="P@ssw0rd"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_URLS=https://+:8081;http://+:8080


ENTRYPOINT ["dotnet", "CatalogAPI.dll"]