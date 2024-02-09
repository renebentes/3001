using System.Security.Cryptography;

namespace JwtStore.Core.AccountContext;

public sealed class Password : ValueObject
{
    private const string Special = "!@#$%^&*(){}[];";
    private const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

    public Password(string? plainText = null)
    {
        if (string.IsNullOrEmpty(plainText) || string.IsNullOrWhiteSpace(plainText))
            plainText = Generate();

        Hash = Hashing(plainText);
    }

    private Password()
    { }

    public string Hash { get; } = string.Empty;

    public string ResetCode { get; } = Guid.NewGuid().ToString("N")[..8].ToUpper();

    public static implicit operator Password(string? plainText)
        => new(plainText);

    public static implicit operator string(Password password)
        => password.ToString();

    public override string ToString()
        => Hash;

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

        password += Settings.PasswordOptions.SaltKey;

        using var algorithm = new Rfc2898DeriveBytes(password,
                                                     saltSize,
                                                     iterations,
                                                     HashAlgorithmName.SHA256);
        var key = algorithm.GetBytes(keySize).ToBase64();
        var salt = algorithm.Salt.ToBase64();

        return $"{iterations}{splitChar}{salt}{splitChar}{key}";
    }

    private static bool Verify(string hash,
                               string password,
                               short keySize = 32,
                               int iterations = 10000,
                               char splitChar = '.')
    {
        password += Settings.PasswordOptions.SaltKey;

        var parts = hash.Split(splitChar, 3);

        if (parts.Length != 3)
            return false;

        var hashIterations = Convert.ToInt32(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var key = Convert.FromBase64String(parts[2]);

        if (hashIterations != iterations)
            return false;

        using var algorithm = new Rfc2898DeriveBytes(password,
                                                     salt,
                                                     iterations,
                                                     HashAlgorithmName.SHA256);
        var keyToCheck = algorithm.GetBytes(keySize);

        return keyToCheck.SequenceEqual(key);
    }
}
