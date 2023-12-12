namespace JwtStore.Core.SharedContext.Extensions;

public static class ByteExtensions
{
    public static string ToBase64(this byte[] bytes)
        => Convert.ToBase64String(bytes);
}
