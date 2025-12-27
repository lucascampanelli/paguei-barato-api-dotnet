# paguei-barato-api-dotnet
API RESTful para facilitar a comparação de preços de produtos no varejo. Construída com ASP .NET.

## Executando e depurando no Visual Studio Code

Recomenda-se instalar a extensão **C#** (`ms-dotnettools.csharp`) no VS Code.

- Para compilar o projeto (task `build`):

```bash
dotnet build PagueiBaratoApi.sln
```

- Para executar a API pelo VS Code via task:

```bash
dotnet run --project src/Api/PagueiBaratoApi.Api.csproj
```

- Para depurar: abra o painel Run (Executar e Depurar) e inicie a configuração ".NET Core Launch (web)". O `preLaunchTask` irá compilar o projeto automaticamente.

As configurações de debug e tasks estão em `.vscode/launch.json` e `.vscode/tasks.json`.
