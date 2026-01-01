# Etap 1: Base - Środowisko uruchomieniowe
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etap 2: Build - Kompilacja i przywracanie zależności
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Kopiowanie pliku projektu i restore (zoptymalizowane pod cache warstw)
COPY ["WeatherForecast.API/WeatherForecast.API.csproj", "WeatherForecast.API/"] 
RUN dotnet restore "WeatherForecast.API/WeatherForecast.API.csproj" 

# Kopiowanie reszty plików źródłowych
COPY . . 
WORKDIR "/src/WeatherForecast.API" 
RUN dotnet build "./WeatherForecast.API.csproj" -c $BUILD_CONFIGURATION -o /app/build 

# Etap 3: Publish - Przygotowanie plików do wydania
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WeatherForecast.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false 

# Etap 4: Final - Produkcyjny obraz końcowy
FROM base AS final
WORKDIR /app 
COPY --from=publish /app/publish . 
ENTRYPOINT ["dotnet", "WeatherForecast.API.dll"]