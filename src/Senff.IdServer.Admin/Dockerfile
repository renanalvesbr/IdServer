FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Senff.IdServer.Admin/Senff.IdServer.Admin.csproj", "src/Senff.IdServer.Admin/"]
COPY ["src/Senff.IdServer.Admin.EntityFramework.Shared/Senff.IdServer.Admin.EntityFramework.Shared.csproj", "src/Senff.IdServer.Admin.EntityFramework.Shared/"]
COPY ["src/Senff.IdServer.Admin.EntityFramework.SqlServer/Senff.IdServer.Admin.EntityFramework.SqlServer.csproj", "src/Senff.IdServer.Admin.EntityFramework.SqlServer/"]
COPY ["src/Senff.IdServer.Admin.EntityFramework.PostgreSQL/Senff.IdServer.Admin.EntityFramework.PostgreSQL.csproj", "src/Senff.IdServer.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/Senff.IdServer.Shared/Senff.IdServer.Shared.csproj", "src/Senff.IdServer.Shared/"]
COPY ["src/Senff.IdServer.Admin.EntityFramework.MySql/Senff.IdServer.Admin.EntityFramework.MySql.csproj", "src/Senff.IdServer.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/Senff.IdServer.Admin/Senff.IdServer.Admin.csproj"
COPY . .
WORKDIR "/src/src/Senff.IdServer.Admin"
RUN dotnet build "Senff.IdServer.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Senff.IdServer.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Senff.IdServer.Admin.dll"]