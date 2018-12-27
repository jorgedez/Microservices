FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Web/Microservices.WebMVC/Microservices.WebMVC.csproj src/Web/Microservices.WebMVC/
COPY src/BuildingBlocks/HealthChecks/src/Microsoft.AspNetCore.HealthChecks/Microsoft.AspNetCore.HealthChecks.csproj src/BuildingBlocks/HealthChecks/src/Microsoft.AspNetCore.HealthChecks/
COPY src/BuildingBlocks/HealthChecks/src/Microsoft.Extensions.HealthChecks/Microsoft.Extensions.HealthChecks.csproj src/BuildingBlocks/HealthChecks/src/Microsoft.Extensions.HealthChecks/
RUN dotnet restore src/Web/Microservices.WebMVC/Microservices.WebMVC.csproj
COPY . .
WORKDIR /src/src/Web/Microservices.WebMVC
RUN dotnet build Microservices.WebMVC.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservices.WebMVC.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservices.WebMVC.dll"]
