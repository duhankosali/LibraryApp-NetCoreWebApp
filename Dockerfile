# See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# SDK image to build and publish our app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy csproj files and restore to cache the layers for faster builds
COPY ["LibraryApp.Web/LibraryApp.Web.csproj", "LibraryApp.Web/"]
COPY ["LibraryApp.Service/LibraryApp.Service.csproj", "LibraryApp.Service/"]
COPY ["LibraryApp.Repository/LibraryApp.Repository.csproj", "LibraryApp.Repository/"]
COPY ["LibraryApp.Core/LibraryApp.Core.csproj", "LibraryApp.Core/"]

RUN dotnet restore "LibraryApp.Web/LibraryApp.Web.csproj"
RUN dotnet restore "LibraryApp.Service/LibraryApp.Service.csproj"
RUN dotnet restore "LibraryApp.Repository/LibraryApp.Repository.csproj"
RUN dotnet restore "LibraryApp.Core/LibraryApp.Core.csproj"

# Copy all the source code and build
COPY . .
WORKDIR "/src/LibraryApp.Web"
RUN dotnet build "LibraryApp.Web.csproj" -c Release -o /app/build

# Publish the API project
FROM build AS publish
RUN dotnet publish "LibraryApp.Web.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "LibraryApp.Web.dll"]