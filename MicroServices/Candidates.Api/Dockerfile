FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MicroServices/Candidates.Api/Candidates.Api.csproj", "MicroServices/Candidates.Api/"]
RUN dotnet restore "MicroServices/Candidates.Api/Candidates.Api.csproj"
COPY . .
WORKDIR "/src/MicroServices/Candidates.Api"
RUN dotnet build "Candidates.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Candidates.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Candidates.Api.dll"]
