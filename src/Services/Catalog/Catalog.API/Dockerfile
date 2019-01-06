FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Catalog/Catalog.API/Catalog.API.csproj", "src/Services/Catalog/Catalog.API/"]
COPY ["src/BuildingBlocks/WebHost.Customization/WebHost.Customization.csproj", "src/BuildingBlocks/WebHost.Customization/"]
COPY ["src/BuildingBlocks/EventBus/IntegrationEventLogEF/IntegrationEventLogEF.csproj", "src/BuildingBlocks/EventBus/IntegrationEventLogEF/"]
COPY ["src/BuildingBlocks/EventBus/EventBus/EventBus.csproj", "src/BuildingBlocks/EventBus/EventBus/"]
COPY ["src/BuildingBlocks/EventBus/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "src/BuildingBlocks/EventBus/EventBusRabbitMQ/"]
COPY ["src/BuildingBlocks/EventBus/EventBusServiceBus/EventBusServiceBus.csproj", "src/BuildingBlocks/EventBus/EventBusServiceBus/"]
RUN dotnet restore "src/Services/Catalog/Catalog.API/Catalog.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Catalog/Catalog.API"
RUN dotnet build "Catalog.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Catalog.API.dll"]