#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# Inside subfolder

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
#COPY ["RedisDemo/RedisDemo.csproj", "RedisDemo/"]
COPY ["RedisDemo.csproj", "RedisDemo/"]
RUN dotnet restore "RedisDemo/RedisDemo.csproj"
#COPY . .
COPY . /src/RedisDemo
WORKDIR "/src/RedisDemo"
RUN dotnet build "RedisDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisDemo.dll"]