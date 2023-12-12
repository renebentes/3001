namespace JwtStore.Core.AccountContext.ValueObjects;

public class Verification : ValueObject
{
    public string Code { get; } = Guid.NewGuid().ToString("N")[..6].ToUpper();

    public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);

    public bool IsActive
        => VerifiedAt is not null && ExpiresAt is null;

    public DateTime? VerifiedAt { get; private set; } = null;

    public void Verify(string code)
    {
        if (IsActive)
            throw new Exception("Código de verificação já ativado!");

        if (ExpiresAt < DateTime.UtcNow)
            throw new Exception("Código de verificação expirado");

        if (!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new Exception("Código de verificação inválido");

        ExpiresAt = null;
        VerifiedAt = DateTime.UtcNow;
    }
}
