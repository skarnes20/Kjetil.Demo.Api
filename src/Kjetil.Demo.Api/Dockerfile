#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Kjetil.Demo.Api/Kjetil.Demo.Api.csproj", "Kjetil.Demo.Api/"]
RUN dotnet restore "Kjetil.Demo.Api/Kjetil.Demo.Api.csproj"
COPY . .
WORKDIR "/src/Kjetil.Demo.Api"
RUN dotnet build "Kjetil.Demo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kjetil.Demo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kjetil.Demo.Api.dll"]
