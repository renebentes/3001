﻿using System.Text;

namespace JwtStore.Core.SharedContext.Extensions;

public static class StringExtensions
{
    public static string ToBase64(this string text)
        => Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
}
