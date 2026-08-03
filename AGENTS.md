# Paguei Barato API (.NET) - Manual Tecnico para Agentes de IA

## Visao Geral
API RESTful em ASP.NET Core para cadastro/autenticacao de usuarios e gerenciamento de dominio do Paguei Barato (ex.: marcas), com autenticacao JWT e persistencia em PostgreSQL via Entity Framework Core.

Projeto em arquitetura por camadas:
- **Api**: Controllers, bootstrap e setup
- **Application**: Casos de uso e orquestracao
- **Core**: Regras centrais de negocio
- **Domain**: Entidades, DTOs, mapeadores e options
- **Infrastructure**: Acesso a dados, contexto EF e migrations

## Stack e Arquitetura
- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core + Npgsql (PostgreSQL)**
- **JWT Bearer Authentication**
- **Swagger/OpenAPI** em ambiente de desenvolvimento
- **Dependency Injection** nativa do ASP.NET Core
- **PasswordHasher** (Microsoft.AspNetCore.Identity)

### Estrutura de Pastas
- `src/Api/`
  - `Controllers/`: endpoints HTTP
  - `Setup/`: configuracoes de DI, autenticacao e banco
  - `Program.cs`: pipeline da aplicacao
- `src/Application/`
  - `Interfaces/`: contratos da camada
  - Implementacoes (`MarcaApplication`, `UsuarioApplication`)
- `src/Core/`
  - `Interfaces/`: contratos de regras centrais
  - Implementacoes (`SenhaCore`, `TokenCore`, `UsuarioCore`)
- `src/Domain/`
  - `Entities/`: entidades de dominio
  - `Dtos/`: request/response por funcionalidade
  - `Mappers/`: conversao entre entidades e DTOs
  - `Options/`: configuracoes tipadas (Secrets/Token)
- `src/Infrastructure/`
  - `Setup/DatabaseContext.cs`
  - `Setup/Configurations/`: mapeamentos EF por entidade
  - `Repository/`: repositorios e interfaces
  - `Migrations/`: historico de migrations

## Entidades Principais
| Entidade | Identificador | Campos Chave |
|----------|---------------|--------------|
| Usuario | GUID | Nome, Email, SenhaHash, auditoria |
| RefreshToken | GUID/int | Token, expiracao, relacao com Usuario |
| Marca | Numerico | Nome, Descricao, auditoria |
| Produto | Numerico | Nome, Marca, categorias, atributos |
| Loja | Numerico | Nome, endereco, ramos |
| Estoque | Numerico | Relacao Produto-Loja e precos |
| Relato | Numerico | Relatos de preco por usuario |
| Categoria/ProdutoCategoria | Numerico | Classificacao de produtos |
| Ramo/LojaRamo | Numerico | Classificacao de lojas |

## Convencoes e Padroes de Desenvolvimento

### Nomenclatura e Codigo
- **Portugues brasileiro sem acentuacao no codigo**.
- Classes/metodos/propriedades em **PascalCase**.
- Variaveis locais e parametros em **camelCase**.
- Sufixo `Async` obrigatorio para metodos assincronos.
- DTOs com sufixos claros (`RequestDto`, `ResponseDto`).
- Interfaces com prefixo `I` (`IUsuarioApplication`, `IMarcaRepository`).

### Camadas e Responsabilidades
- **Controller**: recebe request HTTP, delega para Application, retorna IActionResult.
- **Application**: orquestra fluxo de caso de uso e integra Core/Repository.
- **Core**: regras de negocio puras e servicos centrais (token/senha/usuario).
- **Infrastructure**: persistencia e detalhes de acesso a dados.
- **Domain**: contrato do dominio (entidades, DTOs, mapeamentos e options).

### Inversao de Dependencia (DI)
- Registrar dependencias em `src/Api/Setup/DependencyInjection.cs`.
- Manter contratos em `Interfaces/` e implementacoes nas respectivas camadas.
- Escopo padrao utilizado no projeto: `AddScoped`.

### Persistencia e EF Core
- `DatabaseContext` central em `Infrastructure/Setup`.
- Configuracoes de entidades separadas em `Setup/Configurations`.
- Toda alteracao estrutural deve gerar migration em `Infrastructure/Migrations`.
- Provider padrao: PostgreSQL (`UseNpgsql`).

### Autenticacao e Autorizacao
- JWT configurado em `src/Api/Setup/AuthenticationSetup.cs`.
- Endpoints protegidos com `[Authorize]`; publicos com `[AllowAnonymous]`.
- Claims devem ser lidas de forma explicita (ex.: `ClaimTypes.NameIdentifier` para `criadoPorId`).

### API e Controllers
- Rotas base: `api/[controller]`.
- Preferir:
  - `CreatedAtAction` para criacao
  - `Ok` para consultas/comandos bem sucedidos
- Validacoes de contexto/autenticacao devem retornar status HTTP apropriado (`Unauthorized`, etc.).

### Tratamento de Erros
- Nao mascarar falhas de dominio/integracao.
- Evitar `catch` generico sem acao.
- Propagar excecoes para tratamento consistente no pipeline quando aplicavel.

## Comandos
```bash
dotnet restore PagueiBaratoApi.sln
dotnet build PagueiBaratoApi.sln
dotnet run --project src/Api/PagueiBaratoApi.Api.csproj
```

## Configuracao
- src/Api/appsettings.json 
- src/Api/appsettings.Development.json 

## Campos criticos:
- ConnectionStrings:DefaultConnection 
- Token:Issuer 
- Token:Audience 
- Token:Key 

## Notas Tecnicas
- Solucao organizada para crescimento por dominio mantendo separacao de responsabilidades.

Documentacao Relacionada

- README.md 