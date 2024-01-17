FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Source/Customer/Customer.Management.SupportHub.API/Customer.Management.SupportHub.API.csproj", "Source/Customer/Customer.Management.SupportHub.API/"]
RUN dotnet restore "Source/Customer/Customer.Management.SupportHub.API/Customer.Management.SupportHub.API.csproj"
COPY . .
WORKDIR "/src/Source/Customer/Customer.Management.SupportHub.API"
RUN dotnet build "Customer.Management.SupportHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Customer.Management.SupportHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.Management.SupportHub.API.dll"]
