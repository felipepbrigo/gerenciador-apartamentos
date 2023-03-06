# gerenciador-apartamentos

## Conteúdo

- [Sobre](#about)
- [Como executar](#getting_started)
## Sobre <a name = "about"></a>

Este é um projeto em .NET 6 Utilizando Blazor e PostgreSQL que permite gerenciar apartamentos e seus respectivos moradores. É possível cadastrar, editar e remover apartamentos, além de associar moradores a eles.
## Como executar <a name = "getting_started"></a>

Para executar o projeto localmente, siga as instruções abaixo:

Certifique-se de ter o Visual Studio 2022 com .NET 6 SDK e and ASP.NET workload instalados em sua máquina. Para verificar se você tem o SDK instalado, abra um terminal e execute o comando dotnet --version. Caso não tenha o SDK instalado, faça o download e a instalação através do site oficial da Microsoft. É necessário ter o postgreSQL instalado.

Os seguintes packages foram instalados no Visual Studio 2022 através do Package manager console (podem também ser encontradas ao acessar ao gerenciar as propriedades NuGet dentro do VS), mas serão baixados automáticamente ao abrir o projeto utilizando o Visual Studio 2022 ou Visual Studio Code 2022:
   
   > Microsoft.AspNetCore.Components.WebAssembly.Server      6.0.1       6.0.1   
   > Microsoft.EntityFrameworkCore                           6.0.1       6.0.1   
   > Microsoft.EntityFrameworkCore.Design                    6.0.1       6.0.1   
   > Npgsql                                                  6.0.1       6.0.1   
   > Npgsql.EntityFrameworkCore.PostgreSQL                   6.0.1       6.0.1   
   > Npgsql.EntityFrameworkCore.PostgreSQL.Design            1.1.0       1.1.0   

Conforme mencionado anteriormentte os seguintes workloads foram instalados durante a instalação do Visual Studio 2022:
   > ASP.NET and web development                                                                     
   > .NET Desktop development

Clone este repositório em sua máquina utilizando o comando:

git clone https://github.com/felipepbrigo/gerenciador-apartamentos.git

Acesse o diretório do projeto com o comando cd .\gerenciador-apartamentos\

Acesse o local do arquivo appsettings.json com os seguintes comandos:
cd .\GerenciadorApartamentos\
cd .\Server\

No arquivo appsettings.json, altere as informações de conexão com o banco de dados PostgreSQL de acordo com as configurações do seu ambiente. Certifique-se de ter o PostgreSQL instalado e em execução.

Através do Package manager console:
Rode o comando para que seja instalada o dotnet EF core tools:

dotnet tool install --global dotnet-ef

Ainda no package manager console execute as migrações do banco de dados para criar as tabelas necessárias com o seguinte comandos:

dotnet ef database update

Execute o projeto

Acesse o sistema em seu navegador, através do endereço URL: http://localhost:7287/
