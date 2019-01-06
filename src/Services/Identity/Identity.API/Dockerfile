FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Identity/Identity.API/Identity.API.csproj", "src/Services/Identity/Identity.API/"]
COPY ["src/BuildingBlocks/WebHost.Customization/WebHost.Customization.csproj", "src/BuildingBlocks/WebHost.Customization/"]
RUN dotnet restore "src/Services/Identity/Identity.API/Identity.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Identity/Identity.API"
RUN dotnet build "Identity.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Identity.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Identity.API.dll"]