FROM  mcr.microsoft.com/mssql/server
EXPOSE 1433

COPY . .

ENV SA_PASSWORD "MyP@w0rd"
ENV ACCEPT_EULA "Y"
ENV PATH "$PATH:/opt/mssql-tools/bin"

# Install SQL Server tools
RUN apt-get update && \
    apt-get install -y curl apt-transport-https && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Initialize database
RUN /opt/mssql/bin/sqlservr & sleep 20 \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P ${SA_PASSWORD} -d master \
    -Q "create database core;" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P ${SA_PASSWORD} -d core \
    -e -i ./database/schema.sql

# Start SQL Server
CMD /opt/mssql/bin/sqlservr
