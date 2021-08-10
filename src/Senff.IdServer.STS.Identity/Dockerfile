FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Senff.IdServer.STS.Identity/Senff.IdServer.STS.Identity.csproj", "src/Senff.IdServer.STS.Identity/"]
COPY ["src/Senff.IdServer.Admin.EntityFramework.Shared/Senff.IdServer.Admin.EntityFramework.Shared.csproj", "src/Senff.IdServer.Admin.EntityFramework.Shared/"]
COPY ["src/Senff.IdServer.Shared/Senff.IdServer.Shared.csproj", "src/Senff.IdServer.Shared/"]
RUN dotnet restore "src/Senff.IdServer.STS.Identity/Senff.IdServer.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Senff.IdServer.STS.Identity"
RUN dotnet build "Senff.IdServer.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Senff.IdServer.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Senff.IdServer.STS.Identity.dll"]