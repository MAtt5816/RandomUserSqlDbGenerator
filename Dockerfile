FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

LABEL org.opencontainers.image.source=https://github.com/MAtt5816/RandomUserSqlDbGenerator

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RandomUserSqlDbGenerator.csproj", "./"]
RUN dotnet restore "RandomUserSqlDbGenerator.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "RandomUserSqlDbGenerator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RandomUserSqlDbGenerator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RandomUserSqlDbGenerator.dll"]
