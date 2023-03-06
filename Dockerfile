FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Reto.API/Reto.API/Reto.API.csproj", "src/Reto.API/Reto.API/"]
COPY ["src/Reto.Application/Reto.Application/Reto.Application.csproj", "src/Reto.Application/Reto.Application/"]
COPY ["src/Reto.Infrastructure/Reto.Infrastructure/Reto.Infrastructure.csproj", "src/Reto.Infrastructure/Reto.Infrastructure/"]
COPY ["src/Reto.Domain/Reto.Domain/Reto.Domain.csproj", "src/Reto.Domain/Reto.Domain/"]
RUN dotnet restore "src/Reto.API/Reto.API/Reto.API.csproj"
COPY . .
RUN dotnet build "src/Reto.API/Reto.API/Reto.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Reto.API/Reto.API/Reto.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/mssql/server
ENV SA_PASSWORD=admin
ENV ACCEPT_EULA=Y

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reto.API.dll"]