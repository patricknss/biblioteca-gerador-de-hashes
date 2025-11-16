using System.Security.Cryptography;

namespace Hashing;

public sealed class Sha1HashGenerator : HashGeneratorBase
{
    protected override HashAlgorithm CreateAlgorithm() => SHA1.Create();
}
