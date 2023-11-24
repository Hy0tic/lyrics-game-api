FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["music-game-api/music-game-api.csproj", "music-game-api/"]
RUN dotnet restore "music-game-api/music-game-api.csproj"
COPY . .
WORKDIR "/src/music-game-api"
RUN dotnet build "music-game-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "music-game-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "music-game-api.dll"]
