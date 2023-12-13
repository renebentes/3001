using System.Text;

namespace JwtStore.Core.SharedContext.Extensions;

public static class StringExtensions
{
    public static string ToBase64(this string text)
        => Encoding.ASCII.GetBytes(text).ToBase64();
}
