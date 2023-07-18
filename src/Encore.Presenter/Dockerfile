#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:8000;http://+:80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Encore.Presenter/Encore.Presenter.csproj", "src/Encore.Presenter/"]
COPY ["src/Encore.Application/Encore.Application.csproj", "src/Encore.Application/"]
COPY ["src/Encore.Domain/Encore.Domain.csproj", "src/Encore.Domain/"]
COPY ["src/Encore.Domain.Core/Encore.Domain.Core.csproj", "src/Encore.Domain.Core/"]
COPY ["src/Encore.Infra.CrossCutting/Encore.Infra.CrossCutting.csproj", "src/Encore.Infra.CrossCutting/"]
COPY ["src/Encore.Infra.Data/Encore.Infra.Data.csproj", "src/Encore.Infra.Data/"]
RUN dotnet restore "src/Encore.Presenter/Encore.Presenter.csproj"
COPY . .

WORKDIR "/src/src/Encore.Presenter"
RUN dotnet build "Encore.Presenter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Encore.Presenter.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Encore.Presenter.dll"]