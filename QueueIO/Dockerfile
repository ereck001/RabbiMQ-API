# Imagem base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia os arquivos do projeto
COPY . ./

# Restaura as dependências do projeto
RUN dotnet restore 

# Build da aplicação
RUN dotnet build -c Release -o /app/out

# Define a variável de ambiente ASP.NET Core
ENV ASPNETCORE_URLS=http://+:80

# Exponha a porta do contêiner
EXPOSE 80

# Comando a ser executado quando o contêiner for iniciado
CMD ["dotnet", "run", "--no-build", "--urls", "http://0.0.0.0:80"]

# # Imagem base
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# # Define o diretório de trabalho dentro do container
# WORKDIR /app

# # Copia os arquivos do projeto
# COPY . ./

# # Restaura as dependências do projeto
# RUN dotnet restore 

# # Publica o projeto
# RUN dotnet publish -c Release -o out

# # Imagem final
# FROM mcr.microsoft.com/dotnet/aspnet:6.0

# # Define o diretório de trabalho dentro do container
# WORKDIR /app

# # Copia os arquivos publicados do projeto
# COPY --from=build-env /app/out .

# # Define a variável de ambiente ASP.NET Core
# ENV ASPNETCORE_URLS=http://+:80

# # Expõe a porta do contêiner
# EXPOSE 80

# # Comando a ser executado quando o contêiner for iniciado
# ENTRYPOINT ["dotnet", "RabbitMQApi.dll"]
