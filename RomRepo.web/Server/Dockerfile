#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RomRepo.web/Server/RomRepo.web.Server.csproj", "RomRepo.web/Server/"]
COPY ["RomRepo.web/Client/RomRepo.web.Client.csproj", "RomRepo.web/Client/"]
COPY ["RomRepo.web/Shared/RomRepo.web.Shared.csproj", "RomRepo.web/Shared/"]
RUN dotnet restore "RomRepo.web/Server/RomRepo.web.Server.csproj"
COPY . .
WORKDIR "/src/RomRepo.web/Server"
RUN dotnet build "RomRepo.web.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RomRepo.web.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RomRepo.web.Server.dll"]