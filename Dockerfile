# ----------------------------
# Stage 1: Build
# ----------------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Kopiujemy pliki .sln i wszystkie projekty
COPY *.sln ./
COPY WeatherForecast.*/*.csproj WeatherForecast.*/

# Restore NuGet packages dla całego rozwiązania
RUN dotnet restore

# Kopiujemy resztę plików
COPY . .

# Build i Publish
WORKDIR /src/WeatherForecast.API
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ----------------------------
# Stage 2: Runtime
# ----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
USER $APP_UID

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WeatherForecast.API.dll"]
