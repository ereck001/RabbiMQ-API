# Imagem base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Define o diret�rio de trabalho dentro do container
WORKDIR /app

# Copia os arquivos do projeto
COPY . ./

# Restaura as depend�ncias do projeto
RUN dotnet restore 

# Build da aplica��o
RUN dotnet build -c Release -o /app/out

# Define a vari�vel de ambiente ASP.NET Core
ENV ASPNETCORE_URLS=http://+:80

# Exponha a porta do cont�iner
EXPOSE 80

# Comando a ser executado quando o cont�iner for iniciado
CMD ["dotnet", "run", "--no-build", "--urls", "http://0.0.0.0:80"]

# # Imagem base
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# # Define o diret�rio de trabalho dentro do container
# WORKDIR /app

# # Copia os arquivos do projeto
# COPY . ./

# # Restaura as depend�ncias do projeto
# RUN dotnet restore 

# # Publica o projeto
# RUN dotnet publish -c Release -o out

# # Imagem final
# FROM mcr.microsoft.com/dotnet/aspnet:6.0

# # Define o diret�rio de trabalho dentro do container
# WORKDIR /app

# # Copia os arquivos publicados do projeto
# COPY --from=build-env /app/out .

# # Define a vari�vel de ambiente ASP.NET Core
# ENV ASPNETCORE_URLS=http://+:80

# # Exp�e a porta do cont�iner
# EXPOSE 80

# # Comando a ser executado quando o cont�iner for iniciado
# ENTRYPOINT ["dotnet", "RabbitMQApi.dll"]
