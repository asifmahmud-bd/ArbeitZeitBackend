#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ApiGateways/ApiGateway.Mobile/OcelotApiGateway.Mobile/OcelotApiGateway.Mobile.csproj", "ApiGateways/ApiGateway.Mobile/OcelotApiGateway.Mobile/"]
RUN dotnet restore "ApiGateways/ApiGateway.Mobile/OcelotApiGateway.Mobile/OcelotApiGateway.Mobile.csproj"
COPY . .
WORKDIR "/src/ApiGateways/ApiGateway.Mobile/OcelotApiGateway.Mobile"
RUN dotnet build "OcelotApiGateway.Mobile.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcelotApiGateway.Mobile.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcelotApiGateway.Mobile.dll"]
