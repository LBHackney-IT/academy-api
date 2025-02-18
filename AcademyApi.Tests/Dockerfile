FROM mcr.microsoft.com/dotnet/sdk:8.0

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN

WORKDIR /app

# Copy csproj and nuget config and restore as distinct layers
COPY ./AcademyApi.sln ./
COPY ./AcademyApi/AcademyApi.csproj ./AcademyApi/
COPY ./AcademyApi.Tests/AcademyApi.Tests.csproj ./AcademyApi.Tests/
COPY /NuGet.Config /root/.nuget/NuGet/NuGet.Config

RUN dotnet restore ./AcademyApi/AcademyApi.csproj
RUN dotnet restore ./AcademyApi.Tests/AcademyApi.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out AcademyApi.Tests/AcademyApi.Tests.csproj

CMD dotnet test
