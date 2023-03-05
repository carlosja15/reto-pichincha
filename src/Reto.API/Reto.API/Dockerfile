#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY "../../../" .
WORKDIR /src
RUN dotnet restore "RetoPichincha.sln"
COPY . .

RUN dotnet build "./RetoPichincha.sln" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./RetoPichincha.sln" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/mssql/server
ENV SA_PASSWORD=admin
ENV ACCEPT_EULA=Y

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reto.API.dll"]