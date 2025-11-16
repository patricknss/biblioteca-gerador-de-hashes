using System.Security.Cryptography;

namespace Hashing;

public sealed class Sha256HashGenerator : HashGeneratorBase
{
    protected override HashAlgorithm CreateAlgorithm() => SHA256.Create();
}
