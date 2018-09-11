FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 4234
EXPOSE 44372

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY LNLamasAPI/LNLamasAPI.csproj LNLamasAPI/
RUN dotnet restore LNLamasAPI/LNLamasAPI.csproj
COPY . .
WORKDIR /src/LNLamasAPI
RUN dotnet build LNLamasAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish LNLamasAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LNLamasAPI.dll"]
