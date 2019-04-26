FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WebDocker/WebDocker.csproj", "WebDocker/"]
RUN dotnet restore "WebDocker/WebDocker.csproj"
COPY . .
WORKDIR "/src/WebDocker"
RUN dotnet build "WebDocker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebDocker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebDocker.dll"]