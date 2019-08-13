FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

EXPOSE 5005

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/ZoEazy.Api.STS/ZoEazy.Api.STS.csproj", "src/ZoEazy.Api.STS/"]
RUN dotnet restore "src/ZoEazy.Api.STS/ZoEazy.Api.STS.csproj"
COPY . .
WORKDIR "/src/src/ZoEazy.Api.STS"
RUN dotnet build "ZoEazy.Api.STS.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ZoEazy.Api.STS.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ZoEazy.Api.STS.dll"]