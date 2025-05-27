# API REST MeuPonto
Ferramentas para Desenvolvedores em C# com .NET 7, Entity Framework, SQL Server, Swagger e docker 

![.NET](https://img.shields.io/badge/.NET-7-brightgreen) ![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Latest-blue) ![SQL Server](https://img.shields.io/badge/SQL%20Server-Latest-orange) ![Swagger](https://img.shields.io/badge/Swagger-green) ![Docker](https://img.shields.io/badge/Docker-blue)

 

Esta é uma API REST desenvolvida em C# com o framework .NET 7, usando Entity Framework e SQL Server como banco de dados.

## Modelagem do Banco de Dados


## Funcionalidades Principais

A API oferece as seguintes funcionalidades:


## Requisitos

- [ASP.NET Core 7](https://dotnet.microsoft.com/)
- [Entity Framework](https://docs.microsoft.com/en-us/ef/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)

## Rodando local

1. Clone este repositório em sua máquina local.
2. Certifique-se de ter os requisitos instalados.
3. Configure a conexão com o banco de dados SQL Server no arquivo `appsettings.json`.
4. Execute a migração inicial para criar o esquema do banco de dados.

```shell
dotnet ef database update
```

## Como Usar

1. Inicie o aplicativo.
   ```shell
   dotnet run
   ```

Acesse a API através do seu navegador ou cliente REST, como o Postman ou Insomnia.

## Documentação da API

A documentação da API está disponível através do Swagger. Para acessá-la, siga os passos abaixo:

1. Certifique-se de que o aplicativo está em execução.

2. Abra um navegador da web e acesse o seguinte URL:

`{ambiente}/api/v1/documentation/index.html`
Substitua `{ambiente}` pela porta em que o aplicativo está sendo executado, exemplo: `https://localhost:8080`

## Rotas da API


## Docker

Se preferir, você também pode executar a aplicação em um contêiner Docker. Certifique-se de que o Docker esteja instalado em sua máquina e siga os passos abaixo:

1. Clone este repositório em sua máquina local.

2. Navegue até o diretório do projeto.

3. Execute o seguinte comando para criar a imagem Docker:
```shell
docker build -t nome-da-imagem
docker run -d -p PORTA:PORTA nome-da-imagem
```

Lembre-se de substituir `PORTA` pelo número da porta que você está usando em sua aplicação e `nome-da-imagem` pelo nome da imagem Docker que deseja atribuir.

## Rotas HealthCheck

- `HttpPost {ambiente}/api/status` - Status.
- `HttpPost {ambiente}/api/api/dashboard` - dashboard.


## Licença

Este projeto está sob a licença MIT. Consulte o arquivo LICENSE para obter detalhes.


