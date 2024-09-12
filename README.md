# Controle Financeiro Pessoal

## Descrição

O projeto Controle Financeiro Pessoal é uma aplicação desenvolvida para ajudar a gerenciar e controlar as finanças pessoais de forma eficiente. A aplicação permite a criação e o gerenciamento de pessoas, bancos e lançamentos financeiros e categorias das compras. Com uma interface amigável e funcionalidades práticas, o usuário pode cadastrar, editar e excluir informações financeiras, visualizar relatórios e manter um controle detalhado de suas finanças.

## Tecnologias Utilizadas
- ASP.NET Core MVC: Framework para construção de aplicações web com arquitetura Model-View-Controller (MVC).
- Entity Framework Core: ORM para interação com o banco de dados e gerenciamento de dados.
- C#: Linguagem de programação principal utilizada no desenvolvimento do projeto.
- Bootstrap 5.1: Framework CSS para estilização e design responsivo da interface.
- SQL Server: Sistema de gerenciamento de banco de dados relacional.
- Visual Studio Code: Editor de código utilizado para desenvolvimento.

## Propósito
Este projeto tem como objetivo fornecer uma ferramenta prática e eficiente para o controle financeiro pessoal. Ele permite que os usuários registrem seus gastos e receitas, acompanhem lançamentos financeiros, e obtenham um controle mais detalhado das suas finanças.

## Funcionalidades

- Cadastro e Gerenciamento de Pessoa: Adicione, edite e exclua pessoas.
- Gerenciamento de Lançamentos: Registre e edite lançamentos financeiros, como despesas e receitas.
- Visualização de Relatórios: Acesse relatórios detalhados sobre suas finanças.

## Como Utilizar

### 1-Clonar o Repositório
git clone https://github.com/seu-usuario/controle-financeiro-pessoal.git

### 2-Instalar Dependências
Navegue até o diretório do projeto e instale as dependências necessárias:
cd controle-financeiro-pessoal
dotnet restore

### 3-Configurar o Banco de Dados
Certifique-se de que o SQL Server está instalado e configurado. Atualize a string de conexão no arquivo appsettings.json para apontar para seu banco de dados.
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=ControleFinanceiro;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}

### 4-Executar as Migrations
Aplique as migrations para criar o banco de dados e as tabelas necessárias:
dotnet ef database update

### 5-Executar o Projeto
Inicie o servidor local para rodar a aplicação:
dotnet run


## Contribuições
Sinta-se à vontade para contribuir com melhorias e correções. Para contribuir, por favor siga os seguintes passos:

### 1-Faça um fork do repositório.
### 2-Crie uma branch para sua feature ou correção: git checkout -b minha-feature.
### 3-Faça as alterações necessárias e commite-as: git commit -am 'Adiciona minha feature'.
### 4-Envie para o repositório remoto: git push origin minha-feature.
### 5-Crie um pull request no GitHub.
