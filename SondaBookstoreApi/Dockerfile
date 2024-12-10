# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app

# Copiar os arquivos do projeto
COPY *.csproj ./
RUN dotnet restore

# Migração de banco de dados
# RUN dotnet tool install --global dotnet-ef
# RUN dotnet ef migrations add InitialCreate --project SondaBookstoreApi
# RUN dotnet ef database update

# Copiar o restante dos arquivos e compilar
COPY . ./
RUN dotnet publish -c Release -o /publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:latest AS runtime
WORKDIR /app

# Copiar os arquivos publicados da etapa anterior
COPY --from=build /publish .

# Expor a porta que a API escutará
EXPOSE 5000
EXPOSE 5001

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "SondaBookstoreApi.dll"]
