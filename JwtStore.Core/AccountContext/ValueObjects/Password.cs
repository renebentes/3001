using System.Security.Cryptography;
using JwtStore.Core.AccountContext.Common;

namespace JwtStore.Core.AccountContext.ValueObjects;

public sealed class Password : ValueObject
{
    private const string Special = "!@#$%ˆ&*(){}[];";
    private const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

    public string Hash { get; } = string.Empty;

    public string ResetCode { get; } = Guid.NewGuid().ToString("N")[..8].ToUpper();

    private static string Generate(short length = 16,
                                   bool includeSpecialChars = true,
                                   bool upperCase = false)
    {
        var chars = includeSpecialChars ? (Valid + Special) : Valid;
        var startRandom = upperCase ? 26 : 0;
        var index = 0;
        var res = new char[length];
        var rnd = new Random();

        while (index < length)
            res[index++] = chars[rnd.Next(startRandom, chars.Length)];

        return new string(res);
    }

    private static string Hashing(string password,
                                  short saltSize = 16,
                                  short keySize = 32,
                                  int iterations = 10000,
                                  char splitChar = '.')
    {
        ArgumentException.ThrowIfNullOrEmpty(password);

        password += Settings.SecretsOptions.PasswordSaltKey;

        using var algorithm = new Rfc2898DeriveBytes(password,
                                                     saltSize,
                                                     iterations,
                                                     HashAlgorithmName.SHA256);
        var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
        var salt = Convert.ToBase64String(algorithm.Salt);

        return $"{iterations}{splitChar}{salt}{splitChar}{key}";
    }
}
