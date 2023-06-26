FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV TZ=Etc/GMT+3
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

RUN apt-get update -y
RUN apt-get install -y z3 libz3-dev
RUN apt-get install -y libgdiplus

# Adicionar o serviço do SQL Server
ENV MSSQL_SA_PASSWORD=Encore123
ENV ACCEPT_EULA=Y
RUN apt-get update && apt-get install -y apt-utils
RUN apt-get install -y curl  gnupg gnupg2 gnupg1
RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
RUN curl https://packages.microsoft.com/config/debian/10/prod.list > /etc/apt/sources.list.d/mssql-release.list
RUN apt-get update -y
RUN apt-get install -y mssql-tools unixodbc-dev -y


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Encore.Presenter/Encore.Presenter.csproj", "src/Encore.Presenter/"]
COPY ["src/Encore.Application/Encore.Application.csproj", "src/Encore.Application/"]
COPY ["src/Encore.Domain/Encore.Domain.csproj", "src/Encore.Domain/"]
COPY ["src/Encore.Domain.Core/Encore.Domain.Core.csproj", "src/Encore.Domain.Core/"]
COPY ["src/Encore.Infra.CrossCutting/Encore.Infra.CrossCutting.csproj", "src/Encore.Infra.CrossCutting/"]
COPY ["src/Encore.Infra.Data/Encore.Infra.Data.csproj", "src/Encore.Infra.Data/"]
COPY ["src/Encore.Presenter/Encore.Presenter.csproj", "src/Encore.Presenter/"]

RUN dotnet restore "src/Encore.Presenter/Encore.Presenter.csproj"
COPY . .
WORKDIR "/src/Encore.Presenter"
RUN dotnet build "Encore.Presenter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Encore.Presenter.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Encore.Presenter.dll", "--urls", "http://0.0.0.0:3005"]