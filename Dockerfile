#========================================
# BUILD ANGULAR
#========================================
FROM node:13-alpine AS build-ng

WORKDIR /app

COPY CsetAnalytics/package.json /app/package.json

RUN npm install -g @angular/cli
RUN npm install --loglevel=error

COPY CsetAnalytics /app
RUN ng build --prod

#========================================
# BUILD DOTNET
#========================================
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-dotnet

# Copy  files to image
COPY . /app
WORKDIR /app

# Generate dev certs
RUN mkdir certs
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https -ep ./certs/aspnetapp.pfx -p password

# Build Application
RUN dotnet publish -c Release -o out

#========================================
# RUNTIME
#========================================
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

# Copy artifacts from dotnet build
COPY --from=build-dotnet /app/out /app
COPY --from=build-dotnet /app/certs /certs

# Copy artifacts from angular build
COPY --from=build-ng /app/dist/CsetAnalytics /app/wwwroot/

# Set environment variables for https
ENV ASPNETCORE_URLS="https://+"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/certs/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="password"

# Start API
WORKDIR /app
ENTRYPOINT dotnet CsetAnalytics.Api.dll