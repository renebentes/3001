namespace JwtStore.Core.AccountContext;

public sealed class Email : ValueObject
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

    private Email()
    { }

    public string Address { get; } = string.Empty;

    public string Hash
        => Address.ToBase64();

    public Verification Verification { get; private set; } = new();

    public static implicit operator Email(string address)
        => new(address);

    public static implicit operator string(Email email)
        => email.ToString();

    public void ResetVerification()
        => Verification = new Verification();

    public override string ToString()
        => Address;
}
