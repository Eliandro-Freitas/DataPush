#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DataPush.Api/DataPush.Api.csproj", "DataPush.Api/"]
COPY ["DataPush.Infra/DataPush.Infra.csproj", "DataPush.Infra/"]
COPY ["DataPush.Domain/DataPush.Domain.csproj", "DataPush.Domain/"]
RUN dotnet restore "DataPush.Api/DataPush.Api.csproj"
COPY . .
WORKDIR "/src/DataPush.Api"
RUN dotnet build "DataPush.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataPush.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataPush.Api.dll"]