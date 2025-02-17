FROM mcr.microsoft.com/mssql/server
EXPOSE 1433

COPY . .

ENV MSSQL_SA_PASSWORD "MyP@w0rd"

ENV ACCEPT_EULA "Y"

RUN sudo ACCEPT_EULA=Y apt-get install mssql-tools18 unixodbc-dev

RUN /opt/mssql/bin/sqlservr & sleep 90 \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P ${MSSQL_SA_PASSWORD} -d master \
    -Q "create database core;" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P ${MSSQL_SA_PASSWORD} -d core \
    -e -i ./database/schema.sql

CMD /opt/mssql/bin/sqlservr