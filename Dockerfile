FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["APIKubernetsAndDocker.csproj", "."]
RUN dotnet restore "./APIKubernetsAndDocker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "APIKubernetsAndDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIKubernetsAndDocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIKubernetsAndDocker.dll"]