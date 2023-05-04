
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src


COPY ["MicroServices/IdentityServer/IdentityServer.Application/IdentityServer.Application.csproj","MicroServices/IdentityServer/IdentityServer.Application/"]

RUN dotnet restore "MicroServices/IdentityServer/IdentityServer.Application/IdentityServer.Application.csproj"

COPY . .
WORKDIR "/src/MicroServices/IdentityServer/IdentityServer.Application"
RUN dotnet build "IdentityServer.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer.Application.dll"]