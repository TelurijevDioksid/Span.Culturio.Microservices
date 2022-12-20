#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["Span.Culturio.Users/Span.Culturio.Users.csproj", "Span.Culturio.Users/"]
#COPY ["Span.Culturio.Core/Span.Culturio.Core.csproj", "Span.Culturio.Core/"]
#RUN dotnet restore "Span.Culturio.Users/Span.Culturio.Users.csproj"
#COPY . .
#WORKDIR "/src/Span.Culturio.Users"
#RUN dotnet build "Span.Culturio.Users.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Span.Culturio.Users.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Span.Culturio.Users.dll"]

#--------------------------------------------------------------------------------------------------------------

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY . .
#
#RUN dotnet restore
#
#WORKDIR /src/Span.Culturio.Users
#
#RUN dotnet publish Span.Culturio.Users.csproj -c Release -o /app
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
#
#EXPOSE 80
#WORKDIR /app
#
#COPY --from=build /app .
#
#ENTRYPOINT ["dotnet", "Span.Culturio.Users.dll"]

#--------------------------------------------------------------------------------------------------------------

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore

WORKDIR /src/Span.Culturio.Users
RUN dotnet publish Span.Culturio.Users.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Span.Culturio.Users.dll"]