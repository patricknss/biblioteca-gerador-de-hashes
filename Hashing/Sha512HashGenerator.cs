using System.Security.Cryptography;

namespace Hashing;

public sealed class Sha512HashGenerator : HashGeneratorBase
{
    protected override HashAlgorithm CreateAlgorithm() => SHA512.Create();
}
