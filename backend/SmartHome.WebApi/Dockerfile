# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY *.sln .
COPY SmartHome.Application/SmartHome.Application.csproj ./SmartHome.Application/
COPY SmartHome.WebApi/SmartHome.WebApi.csproj ./SmartHome.WebApi/
COPY SmartHome.Data/SmartHome.Data.csproj ./SmartHome.Data/
COPY SmartHome.DataTransferObjects/SmartHome.DataTransferObjects.csproj ./SmartHome.DataTransferObjects/
COPY SmartHome.Domain/SmartHome.Domain.csproj ./SmartHome.Domain/

# Copy the countries.csv file to the /src directory
COPY SmartHome.Data/countries.csv .

# Restore dependencies
RUN dotnet restore

# Copy the entire solution to the container
COPY . .

# Build the application
RUN dotnet build -c Release -o /app/build

# Stage 2: Publish the application
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS publish
WORKDIR /app
COPY --from=build /app/build .

# Copy the countries.csv file to the /app directory
COPY --from=build /src/countries.csv .

# Stage 3: Final runtime image
FROM publish AS final
WORKDIR /app

# Entry point for the application
ENTRYPOINT ["dotnet", "SmartHome.WebApi.dll"]
