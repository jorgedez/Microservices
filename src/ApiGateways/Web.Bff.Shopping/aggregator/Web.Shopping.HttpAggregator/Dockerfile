FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/ApiGateways/Web.Bff.Shopping/aggregator/Web.Shopping.HttpAggregator/Web.Shopping.HttpAggregator.csproj", "src/ApiGateways/Web.Bff.Shopping/aggregator/Web.Shopping.HttpAggregator/"]
RUN dotnet restore "src/ApiGateways/Web.Bff.Shopping/aggregator/Web.Shopping.HttpAggregator/Web.Shopping.HttpAggregator.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/Web.Bff.Shopping/aggregator/Web.Shopping.HttpAggregator"
RUN dotnet build "Web.Shopping.HttpAggregator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Web.Shopping.HttpAggregator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Web.Shopping.HttpAggregator.dll"]