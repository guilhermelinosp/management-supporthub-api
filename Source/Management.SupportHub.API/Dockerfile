FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Source/Company.Management.SupportHub.API/Company.Management.SupportHub.API.csproj", "Source/Company.Management.SupportHub.API/"]
COPY ["Source/Company.Management.SupportHub.Application/Company.Management.SupportHub.Application.csproj", "Source/Company.Management.SupportHub.Application/"]
COPY ["Source/Company.Management.SupportHub.Domain/Company.Management.SupportHub.Domain.csproj", "Source/Company.Management.SupportHub.Domain/"]
COPY ["Source/Company.Management.SupportHub.Infrastructure/Company.Management.SupportHub.Infrastructure.csproj", "Source/Company.Management.SupportHub.Infrastructure/"]
RUN dotnet restore "Source/Company.Management.SupportHub.API/Company.Management.SupportHub.API.csproj"
COPY . .
WORKDIR "/src/Source/Company.Management.SupportHub.API"
RUN dotnet build "Company.Management.SupportHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Company.Management.SupportHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.Management.SupportHub.API.dll"]
