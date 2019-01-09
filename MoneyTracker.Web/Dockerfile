FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MoneyTracker.Web/MoneyTracker.Web.csproj", "MoneyTracker.Web/"]
RUN dotnet restore "MoneyTracker.Web/MoneyTracker.Web.csproj"
COPY . .
WORKDIR "/src/MoneyTracker.Web"
RUN dotnet build "MoneyTracker.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MoneyTracker.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MoneyTracker.Web.dll"]