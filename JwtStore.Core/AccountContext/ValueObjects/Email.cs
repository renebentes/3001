using JwtStore.Core.SharedContext.Common;

namespace JwtStore.Core.AccountContext.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        ArgumentException.ThrowIfNullOrEmpty(address);

        Address = address.Trim().ToLower();

        if (Address.Length < 5)
            throw new Exception("E-mail inválido");

        if (!RegexPatterns.EmailRegex().IsMatch(Address))
            throw new Exception("E-mail inválido");
    }

    public string Address { get; } = string.Empty;

    public string Hash
        => Address.ToBase64();

    public override string ToString()
        => Address;

    public static implicit operator string(Email email)
        => email.ToString();

    public static implicit operator Email(string address)
        => new(address);
}
