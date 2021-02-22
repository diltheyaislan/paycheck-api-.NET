FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:$PORT
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_USE_POLLING_FILE_WATCHER=true

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PaycheckAPI/PaycheckAPI.csproj", "PaycheckAPI/"]
RUN dotnet restore "PaycheckAPI/PaycheckAPI.csproj"
COPY . .
WORKDIR "/src/PaycheckAPI"
RUN dotnet build "PaycheckAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaycheckAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD dotnet PaycheckAPI.dll --urls=http://+::$PORT --environment=Production
