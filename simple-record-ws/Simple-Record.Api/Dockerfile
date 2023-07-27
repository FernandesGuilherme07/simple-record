#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Simple-Record.Api/Simple-Record.Api.csproj", "Simple-Record.Api/"]
COPY ["Simple-Record.Application/Simple-Record.Application.csproj", "Simple-Record.Application/"]
COPY ["Simple-Record.Core/Simple-Record.Core.csproj", "Simple-Record.Core/"]
COPY ["Simple-Record.Infra/Simple-Record.Infra.csproj", "Simple-Record.Infra/"]
RUN dotnet restore "Simple-Record.Api/Simple-Record.Api.csproj"
COPY . .
WORKDIR "/src/Simple-Record.Api"
RUN dotnet build "Simple-Record.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Simple-Record.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simple-Record.Api.dll"]