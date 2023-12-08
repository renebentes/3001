namespace JwtStore.Core.AccountContext.ValueObjects;

public class Email : ValueObject
{
    public string Address { get; } = string.Empty;

    public string Hash
        => Address.ToBase64();
}
