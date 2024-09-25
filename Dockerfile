FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5432

ENV ASPNETCORE_URLS=http://+:5432

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Dream-Reserve-Back.csproj", "./"]
RUN dotnet restore "Dream-Reserve-Back.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Dream-Reserve-Back.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Dream-Reserve-Back.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY .env .
ENTRYPOINT ["dotnet", "Dream-Reserve-Back.dll"]
