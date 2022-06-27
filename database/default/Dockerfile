FROM  mcr.microsoft.com/mssql/server
EXPOSE 1433

COPY . .

ENV SA_PASSWORD "MyP@w0rd"

ENV ACCEPT_EULA "Y"

RUN /opt/mssql/bin/sqlservr & sleep 20 \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P ${SA_PASSWORD} -d master \
    -Q "create database core;" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P ${SA_PASSWORD} -d core \
    -e -i ./database/schema.sql

CMD /opt/mssql/bin/sqlservr
