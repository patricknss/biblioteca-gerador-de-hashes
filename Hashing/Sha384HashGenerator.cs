using System.Security.Cryptography;

namespace Hashing;

public sealed class Sha384HashGenerator : HashGeneratorBase
{
    protected override HashAlgorithm CreateAlgorithm() => SHA384.Create();
}
