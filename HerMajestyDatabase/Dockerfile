FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HerMajestyDatabase/HerMajestyDatabase.csproj", "HerMajestyDatabase/"]
RUN dotnet restore "HerMajestyDatabase/HerMajestyDatabase.csproj"
COPY . .
WORKDIR "/src/HerMajestyDatabase"
RUN dotnet build "HerMajestyDatabase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HerMajestyDatabase.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HerMajestyDatabase.dll"]
