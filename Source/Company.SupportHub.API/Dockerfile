FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Source/Company.SupportHub.API/Company.SupportHub.API.csproj", "Source/Company.SupportHub.API/"]
COPY ["Source/Company.SupportHub.Application/Company.SupportHub.Application.csproj", "Source/Company.SupportHub.Application/"]
COPY ["Source/Company.SupportHub.Domain/Company.SupportHub.Domain.csproj", "Source/Company.SupportHub.Domain/"]
COPY ["Source/Company.SupportHub.Infrastructure/Company.SupportHub.Infrastructure.csproj", "Source/Company.SupportHub.Infrastructure/"]
RUN dotnet restore "Source/Company.SupportHub.API/Company.SupportHub.API.csproj"
COPY . .
WORKDIR "/src/Source/Company.SupportHub.API"
RUN dotnet build "Company.SupportHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Company.SupportHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.SupportHub.API.dll"]
