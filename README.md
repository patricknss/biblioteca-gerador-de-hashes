# Gerador de Hash

Autor: Patrick Noronha

Implementação em C# focada em arquitetura limpa para geração de hashes (MD5, SHA1, SHA256, SHA384 e SHA512) utilizando `System.Security.Cryptography`. O projeto é composto por uma biblioteca reutilizável (`Hashing`) e uma interface de linha de comando (`Hashing.Console`).

## Arquitetura

```
Gerador de Hash/
├── Hashing/            # Biblioteca com contratos, implementações e serviços
├── Hashing.Console/    # CLI que consome HashService
└── Hashing.Tests/      # (reservado) Projeto de testes unitários
```

A biblioteca segue os princípios:
- **Baixo acoplamento**: consumidores interagem apenas via `IHashGenerator`, `HashService` e `HashGeneratorFactory`.
- **Alta coesão**: cada algoritmo possui sua própria classe (`Md5HashGenerator`, `Sha256HashGenerator`, etc.).
- **Extensibilidade**: novos algoritmos exigem somente uma implementação de `HashGeneratorBase` e atualização da `HashGeneratorFactory`.

## Requisitos
- .NET SDK 8.0+ (o console tem como alvo `net9.0`, compatível com SDK 9.0).

Verifique sua versão com:

```powershell
 dotnet --version
```

## Configuração

Restaure dependências (o template já referencia a biblioteca):

```powershell
cd "."
dotnet restore
```

## Build

Compile a biblioteca e o console:

```powershell
dotnet build Hashing\Hashing.csproj
dotnet build Hashing.Console\Hashing.Console.csproj
```

## Uso do CLI

O console aceita dois parâmetros: algoritmo e texto. Algoritmos válidos: `md5`, `sha1`, `sha256`, `sha384`, `sha512`.

```powershell
dotnet run --project Hashing.Console -- sha256 "hello world"
```

Saída esperada (exemplo):

```
64EC88CA00B268E5BA1A35678A1B5316D212F4F366B247724E5B0F3F0C4A331F
```

### Outras formas de consumo
- Referencie `Hashing` em outros projetos e injete `HashService` onde precisar.
- Utilize `HashGeneratorFactory` diretamente para selecionar o algoritmo e chamar `Compute`.

## Testes

O diretório `Hashing.Tests` está reservado para futuros testes com vetores canônicos (ex.: `"hello" -> 2CF24D...` para SHA256). Assim que os testes forem adicionados, rode-os com:

```powershell
dotnet test Hashing.Tests\Hashing.Tests.csproj
```

## Próximos passos
1. Implementar o projeto de testes unitários com vetores conhecidos para cada algoritmo.
2. Adicionar suporte a novos algoritmos ou formatos de saída (ex.: Base64) caso necessário.

