FROM mcr.microsoft.com/mssql/server
EXPOSE 1433

COPY . .

ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=MyP@w0rd
ENV PATH="$PATH:/opt/mssql-tools/bin"

# Switch to root to install dependencies
USER root

# Install dependencies and the SQL Server tools
RUN apt-get update && \
    apt-get install -yq curl apt-transport-https && \
    # Get official Microsoft repository configuration
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/16.04/mssql-server-2017.list | tee /etc/apt/sources.list.d/mssql-server.list && \
    apt-get update && \
    # Install SQL Server from apt
    apt-get install -y mssql-server && \
    # Cleanup the Dockerfile
    apt-get clean && \
    rm -rf /var/lib/apt/lists

# Switch back to the default user
USER mssql

# Initialize database
RUN /opt/mssql/bin/sqlservr & sleep 20 \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P ${SA_PASSWORD} -d master \
    -Q "create database core;" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P ${SA_PASSWORD} -d core \
    -e -i ./database/schema.sql

# Start SQL Server
CMD /opt/mssql/bin/sqlservr
