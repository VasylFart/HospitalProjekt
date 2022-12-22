# About

V-Project provide a tool to manage retirement homes.

## Prerequisites

- .NET 6.0
- node.js 16.15 & npm 8.5.5

## Local UserSecrets

- To use local UserSecrets instead of Dev Azure Key Vault you could change `"UseUserSecrets"` environmentVariable to `"true"` in launchSettings.json.
- To set up Local UserSecrets:
    - Store mandatory secrets in the [Secret Manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows#secret-manager):
        - Create Connection string secret for your local db: `cd server\src\host\V-Project.Server && dotnet user-secrets init && dotnet user-secrets set SqlDatabase:ConnectionString ***`

## Local Database

- To use local database instead of InMemoryDatabase you could change `"UseInMemoryDatabase"` environmentVariable to `"false"` in launchSettings.json.
- To set up Local Database:
    - Install Entity Framework CLI `dotnet tool install --global dotnet-ef`
    - Database update with latest migration: `dotnet ef database update --project server/src/infrastructure/V-Project.Sql --startup-project server/src/host/V-Project.Server`
    - More info on [EF Core tool options](https://docs.microsoft.com/en-us/ef/core/cli/dotnet#common-options)

## Migrations

- Initial migration: `dotnet ef migrations add InitialCreate --project server/src/infrastructure/V-Project.Sql --startup-project server/src/host/V-Project.Server --context ApplicationDbContext`

## Tips & Tricks

- Consult the scripts in the top-level `package.json` for details on how to build and test the project.
- For C# dev in VS Code, remember to point the OmniSharp extension at the right solution ("OmniSharp: Select Project" from the command palette).
- For TypeScript dev in VS Code, make sure you [select the workspace version of TypeScript](https://code.visualstudio.com/docs/typescript/typescript-compiling#_using-the-workspace-version-of-typescript).
- To find info about a [SonarSource rule for C#](https://rules.sonarsource.com/csharp), use this URI template: `https://rules.sonarsource.com/csharp/RSPEC-{ruleId}`

## Recommended tools

- Visual Studio Code
- For C# you can also use Visual Studio (2022)
- Recommended VS Code extensions:
  - [EditorConfig](https://marketplace.visualstudio.com/items?itemName=EditorConfig.EditorConfig)
  - [C# (OmniSharp)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
  - [ESLint](https://marketplace.visualstudio.com/items?itemName=dbaeumer.vscode-eslint)
  - [PowerShell](https://marketplace.visualstudio.com/items?itemName=ms-vscode.PowerShell)
  - [Azure Pipelines](https://marketplace.visualstudio.com/items?itemName=ms-azure-devops.azure-pipelines)
  - [Azure Resource Manager](https://marketplace.visualstudio.com/items?itemName=msazurermtools.azurerm-vscode-tools)
  - [Spell Right](https://marketplace.visualstudio.com/items?itemName=ban.spellright)

# Contribute

The project uses GitFlow-style branching model. Contribute features or fixes by opening a pull request against the `main` branch.

## Coding standard

### C#

1. Avoid namespace explosion. Grouping files into folders is encouraged, but it doesn't have to mean a new namespace. This just makes the inevitable re-organization of files and folders more painful, makes it harder for IntelliSense to find things (e.g. extension methods), and leads to many unnecessary import statements (making it harder to see the important import statements). Therefore, use namespaces judiciously.
2. Don't use expression bodies for multi-line members.