#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Employee/Attendance/Attendance.Api/Attendance.Api.csproj", "Services/Employee/Attendance/Attendance.Api/"]
COPY ["Services/Employee/Attendance/Attendance.Service/Attendance.Application.csproj", "Services/Employee/Attendance/Attendance.Service/"]
RUN dotnet restore "Services/Employee/Attendance/Attendance.Api/Attendance.Api.csproj"
COPY . .
WORKDIR "/src/Services/Employee/Attendance/Attendance.Api"
RUN dotnet build "Attendance.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Attendance.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Attendance.Api.dll"]
