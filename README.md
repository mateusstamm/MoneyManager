# Money Manager

![Logo](MoneyManager.Pages\wwwroot\images\logo.png)

Money Manager é um aplicativo web para gerenciamento financeiro pessoal, onde os usuários podem acompanhar suas despesas e receitas, categorizar transações, definir metas financeiras e visualizar relatórios detalhados.

## Funcionalidades

- Cadastro e autenticação de usuários
- Adição, edição e exclusão de transações financeiras
- Categorização de transações por tipo (despesa ou receita) e categoria
- Visualização de resumo financeiro com gastos totais, receitas totais e saldo total
- Geração de gráfico de linhas para acompanhar as transações nos últimos 7 dias

## Tecnologias Utilizadas

- ASP.NET Core: Framework para desenvolvimento de aplicativos web
- Razor Pages: Modelo de programação do ASP.NET Core para criação de páginas web
- Entity Framework Core: ORM (Object-Relational Mapping) para acesso a dados
- HTML, CSS e JavaScript: Linguagens de marcação e programação para construção da interface do usuário
- Bootstrap: Framework CSS para criação de layouts responsivos
- Chart.js: Biblioteca JavaScript para criação de gráficos interativos

## Pré-requisitos

- Docker: [Instalação do Docker](https://docs.docker.com/engine/install/ubuntu/)
- Docker-Compose

## Configuração do Ambiente

1. Clone o repositório: `git clone https://github.com/mateusstamm/MoneyManager.git`
2. Navegue até o diretório do projeto: `cd MoneyManager`
3. Dê o comando: `docker-compose up --build -d`
6. Acesse o aplicativo no navegador: `http://localhost:50001`

## Contribuidores

- [Seu Nome](https://github.com/mateusstamm) - Desenvolvedor

## Licença

Este projeto está licenciado sob a [MIT License](https://opensource.org/licenses/MIT).
