FROM mcr.microsoft.com/mssql/server
EXPOSE 1433

COPY . .

ENV MSSQL_SA_PASSWORD "MyP@w0rd"
ENV ACCEPT_EULA "Y"

USER root
RUN ACCEPT_EULA=Y apt-get update && apt-get install -y mssql-tools18 unixodbc-dev
USER mssql

RUN /opt/mssql/bin/sqlservr & sleep 20 \
    && /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P ${MSSQL_SA_PASSWORD} -d master -C \
    -Q "create database core;" \
    && /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P ${MSSQL_SA_PASSWORD} -d core -C \
    -e -i ./database/schema.sql

CMD /opt/mssql/bin/sqlservr