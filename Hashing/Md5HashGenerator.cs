using System.Security.Cryptography;

namespace Hashing;

public sealed class Md5HashGenerator : HashGeneratorBase
{
    protected override HashAlgorithm CreateAlgorithm() => MD5.Create();
}
