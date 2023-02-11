FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy all the layers' csproj files into respective folders
COPY ["./ZeroDefects/ZeroDefects.API.csproj", "src/ZeroDefects/"]
COPY ["./ZeroDefects.Application/ZeroDefects.Application.csproj", "src/ZeroDefects.Application/"]
COPY ["./ZeroDefects.Commands/ZeroDefects.Commands.csproj", "src/ZeroDefects.Commands/"]
COPY ["./ZeroDefects.Queries/ZeroDefects.Queries.csproj", "src/ZeroDefects.Queries/"]
COPY ["./ZeroDefects.Domain/ZeroDefects.Domain.csproj", "src/ZeroDefects.Domain/"]
COPY ["./ZeroDefects.Tests/ZeroDefects.Tests.csproj", "src/ZeroDefects.Tests/"]
COPY ["./ZeroDefects.Infrastructure/ZeroDefects.Infrastructure.csproj", "src/ZeroDefects.Infrastructure/"]

# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "src/ZeroDefects/ZeroDefects.API.csproj"

COPY . .

# run build over the API project
WORKDIR "/src/ZeroDefects/"
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "ZeroDefects.API.dll" ]