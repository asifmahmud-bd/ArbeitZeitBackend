#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Identity/IdentityService.Api/IdentityService.Api.csproj", "Services/Identity/IdentityService.Api/"]
COPY ["Services/Identity/IdentityService.Service/IdentityService.Application.csproj", "Services/Identity/IdentityService.Service/"]
RUN dotnet restore "Services/Identity/IdentityService.Api/IdentityService.Api.csproj"
COPY . .
WORKDIR "/src/Services/Identity/IdentityService.Api"
RUN dotnet build "IdentityService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityService.Api.dll"]
