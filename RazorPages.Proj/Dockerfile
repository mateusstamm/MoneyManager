# Define a imagem base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura as dependências
COPY . ./
RUN dotnet restore

RUN dotnet tool install --global dotnet-ef --version 7.0.5

ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet ef migrations add InitialCreate

#RUN dotnet ef database update

# Publica a aplicação
RUN dotnet publish -c Release -o out

# Define a imagem de execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 58080

ENTRYPOINT ["dotnet", "RazorPages.Proj.dll"]