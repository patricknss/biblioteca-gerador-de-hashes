using System;

namespace Hashing;

public sealed class HashGeneratorFactory
{
    public IHashGenerator Create(HashAlgorithmType type) => type switch
    {
        HashAlgorithmType.Md5 => new Md5HashGenerator(),
        HashAlgorithmType.Sha1 => new Sha1HashGenerator(),
        HashAlgorithmType.Sha256 => new Sha256HashGenerator(),
        HashAlgorithmType.Sha384 => new Sha384HashGenerator(),
        HashAlgorithmType.Sha512 => new Sha512HashGenerator(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported hash algorithm")
    };
}
