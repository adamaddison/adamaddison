# =========================
# 1. Build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution file
COPY adamaddison.sln .

# Copy project files
COPY adamaddison/adamaddison.csproj adamaddison/
COPY adamaddison.Tests/adamaddison.Tests.csproj adamaddison.Tests/

# Restore dependencies for all projects
RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Publish ONLY the web project
RUN dotnet publish adamaddison/adamaddison.csproj -c Release -o /app/publish
# (Tests are ignored here — they are not published)

# =========================
# 2. Runtime stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "adamaddison.dll"]
