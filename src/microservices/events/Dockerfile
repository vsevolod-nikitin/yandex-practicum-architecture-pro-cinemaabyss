FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8002

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/microservices/events/CinemaAbyss.Events/CinemaAbyss.Events.csproj", "src/microservices/events/CinemaAbyss.Events/"]
RUN dotnet restore "./src/microservices/events/CinemaAbyss.Events/CinemaAbyss.Events.csproj"
COPY . .
WORKDIR "/src/src/microservices/events/CinemaAbyss.Events"
RUN dotnet build "./CinemaAbyss.Events.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CinemaAbyss.Events.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CinemaAbyss.Events.dll"]