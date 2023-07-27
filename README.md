# CRUD Simples de Pessoas e Endereços

## Backend

### Tecnologias Utilizadas

- Plataforma: .NET 7.0
- Framework Web: ASP.NET Core
- Acesso a Dados: EF Core
- Banco de Dados: SQL Server
- Validações e Notificações de Domínio: Flunt
- Testes Unitários: MSTest

### Estrutura das Camadas da Aplicação

1. **Simple-Record.Core:** Nesta camada, encontra-se toda a regra de negócio e o coração da aplicação. Aqui, são definidas as entidades de domínio, enums e notificações de domínio.

2. **Simple-Record.Application:** Aqui ficam todas as regras de aplicação, incluindo mapeamento de dados, modelos da aplicação, DTOs, serviços e casos de uso. Os casos de uso foram agrupados por contexto dentro dos serviços para manter a simplicidade do projeto.

3. **Simple-Record.Infra:** Responsável pela persistência de dados. Também pode ser utilizada para adicionar serviços externos da aplicação, como mensageria e gateways.

4. **Simple-Record.API:** Camada web da aplicação, responsável por resolver as dependências da aplicação.

### Padrões e Arquitetura

Optou-se pelo uso de padrões da arquitetura limpa e DDD (Domain-Driven Design). Esses padrões prezam pelo isolamento do core da aplicação em camadas, tornando-a mais manutenível e testável. Embora seja uma aplicação simples, a utilização desses padrões foi uma oportunidade para aplicar conceitos e conhecimentos avançados.

### Como Rodar a Aplicação

A aplicação roda em um container Docker Linux orquestrado pelo Docker Compose para gerenciar tanto a aplicação como o banco de dados. Para rodar a aplicação, é necessário ter o Docker instalado em sua máquina e é indicado o uso da IDE Visual Studio para maior facilidade.

#### No Visual Studio

1. Se o Docker rodar no Windows, vá até o arquivo `appsettings.development.json` e substitua a string de conexão atual por: 
```
"Server={IP_DA_MAQUINA_QUE_SEU_DOCKER_ESTÁ_RODANDO},1433;Database=simplerecord;User ID=sa;Password=1q2w3e4r@#$; TrustServerCertificate=true;"
```


2. Se o Docker estiver rodando diretamente em sua máquina, abra a solução da aplicação e, nas opções de projetos de inicialização, escolha a opção "Simple-Record.Docker-Compose-Host". Isso iniciará o container com a aplicação e o banco de dados, executando as migrations. Feito isso, a API estará rodando em sua máquina em https://localhost:80.

## Frontend

### Tecnologias Utilizadas

- Framework SPA: React
- Biblioteca de Componentes: MaterialUI
- Gerenciamento de Estados: Mobx-React
- Chamadas HTTP: Axios
- Notificações Push: React-Toastify
- Roteamento: React-Router-DOM

### Estrutura da Aplicação

1. **src/core:** Camada responsável por armazenar os contratos da aplicação.

2. **src/services:** Camada responsável pelas chamadas HTTP da aplicação.

3. **src/stores:** Camada responsável pelo gerenciamento de estado da aplicação com Mobx-React.

4. **src/utils:** Camada responsável por armazenar funções de utilidade na aplicação, como formatações.

5. **src/styles:** Camada responsável pelo estilo global da aplicação.

6. **src/routes:** Responsável pelo roteamento da aplicação.

7. **src/pages:** Páginas da aplicação.

8. **src/components:** Componentes da aplicação.

### Como Rodar a Aplicação

Para rodar a aplicação, basta abrir o terminal na pasta raiz da aplicação frontend e executar os seguintes comandos:

1. `npm install` - Para instalação das dependências da aplicação.

2. `npm start` - Para iniciar a aplicação web.

Sua aplicação estará rodando em http://localhost:3000.

Aproveite e divirta-se explorando a aplicação de CRUD simples de pessoas e endereços!
