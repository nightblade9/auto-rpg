FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 51529
EXPOSE 44330

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AutoRpg.Web/AutoRpg.Web.csproj", "AutoRpg.Web/"]
RUN dotnet restore "AutoRpg.Web/AutoRpg.Web.csproj"
COPY . .
WORKDIR "/src/AutoRpg.Web"
RUN dotnet build "AutoRpg.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AutoRpg.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AutoRpg.Web.dll"]