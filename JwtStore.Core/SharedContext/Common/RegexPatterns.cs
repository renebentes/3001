using System.Text.RegularExpressions;

namespace JwtStore.Core.SharedContext.Common;

public sealed partial class RegexPatterns
{
    private const string EmailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    [GeneratedRegex(EmailPattern)]
    public static partial Regex EmailRegex();
}
