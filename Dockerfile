FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=sua_senha_forte

COPY create_user.sql /docker-entrypoint-initdb.d/

EXPOSE 1433

CMD ["/opt/mssql/bin/sqlservr"]
