FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EFcore-practise2/EFcore-practise2.csproj", "EFcore-practise2/"]
RUN dotnet restore "EFcore-practise2/EFcore-practise2.csproj"
COPY . .
WORKDIR "/src/EFcore-practise2"
RUN dotnet build "EFcore-practise2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFcore-practise2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFcore-practise2.dll"]
