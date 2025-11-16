using System;

namespace Hashing;

public sealed class HashService
{
    private readonly HashGeneratorFactory _factory;

    public HashService(HashGeneratorFactory factory)
    {
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    public string Compute(HashAlgorithmType algorithmType, string input)
    {
        var generator = _factory.Create(algorithmType);
        return generator.Compute(input);
    }
}
