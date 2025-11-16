using Hashing;

if (args.Length < 2)
{
	PrintUsage();
	return;
}

var algorithmName = args[0];
var input = string.Join(" ", args[1..]);

if (!Enum.TryParse<HashAlgorithmType>(algorithmName, true, out var algorithmType))
{
	Console.Error.WriteLine($"Algoritmo inválido: {algorithmName}");
	PrintUsage();
	return;
}

var service = new HashService(new HashGeneratorFactory());
var hash = service.Compute(algorithmType, input);
Console.WriteLine(hash);

static void PrintUsage()
{
	Console.WriteLine("Uso: dotnet run --project Hashing.Console -- <algoritmo> <texto>");
	Console.WriteLine("Algoritmos suportados: md5, sha1, sha256, sha384, sha512");
}
