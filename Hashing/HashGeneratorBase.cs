using System;
using System.Security.Cryptography;
using System.Text;

namespace Hashing;

public abstract class HashGeneratorBase : IHashGenerator
{
    public string Compute(string input)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        using var algorithm = CreateAlgorithm();
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = algorithm.ComputeHash(inputBytes);
        return ConvertToHex(hashBytes);
    }

    protected abstract HashAlgorithm CreateAlgorithm();

    private static string ConvertToHex(ReadOnlySpan<byte> data)
    {
        Span<char> buffer = stackalloc char[data.Length * 2];
        const string HexAlphabet = "0123456789ABCDEF";

        for (var i = 0; i < data.Length; i++)
        {
            var b = data[i];
            buffer[i * 2] = HexAlphabet[b >> 4];
            buffer[(i * 2) + 1] = HexAlphabet[b & 0xF];
        }

        return new string(buffer);
    }
}
