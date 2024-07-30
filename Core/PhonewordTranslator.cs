using System.Text;

namespace Core;

public static class PhonewordTranslator
{
    public static string? ToNumber(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
        {
            return null;
        }

        raw = raw.ToUpperInvariant();

        StringBuilder newNumber = new();
        foreach (char c in raw)
        {
            if (" -0123456789".Contains(c))
            {
                _ = newNumber.Append(c);
            }
            else
            {
                int? result = TranslateToNumber(c);
                if (result != null)
                {
                    _ = newNumber.Append(result);
                }
                // Bad character?
                else
                {
                    return null;
                }
            }
        }
        return newNumber.ToString();
    }

    private static readonly string[] _digits = [
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
    ];

    private static int? TranslateToNumber(char c)
    {
        for (int i = 0; i < _digits.Length; i++)
        {
            if (_digits[i].Contains(c))
            {
                return 2 + i;
            }
        }
        return null;
    }
}