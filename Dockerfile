FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SLAMobileApi/SLAMobileApi.csproj", "SLAMobileApi/"]
RUN dotnet restore "SLAMobileApi/SLAMobileApi.csproj"
COPY . .
WORKDIR "/src/SLAMobileApi"
RUN dotnet build "SLAMobileApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SLAMobileApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SLAMobileApi.dll"]
