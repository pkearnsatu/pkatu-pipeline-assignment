# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install Node.js and npm (required for Snyk)
RUN apt-get update && apt-get install -y \
    nodejs \
    npm

# Install Snyk globally
RUN npm install -g snyk

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["pkatu-pipeline-assignment.csproj", "./"]
RUN dotnet restore "pkatu-pipeline-assignment.csproj"
COPY . .
#WORKDIR "/src/pkatu-pipeline-assignment"
RUN dotnet build "pkatu-pipeline-assignment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pkatu-pipeline-assignment.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pkatu-pipeline-assignment.dll"]
