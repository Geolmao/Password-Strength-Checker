using System;

namespace PasswordCheckerWeb.Helpers;

public class Utils
{
    private static string SpecialChars = "!@#$%^&*()_+}{|></.}";
    private static string DigitsChars = "1234567890";
    private static HashSet<string> CommonPass = new HashSet<string>
    {
        "123456",
        "password",
        "123456789",
        "12345678",
        "12345",
        "111111",
        "123123",
        "qwerty",
        "abc123",
        "password1",
        "1234",
        "iloveyou",
        "admin",
        "welcome",
        "monkey",
        "login",
        "letmein",
        "football",
        "dragon",
        "sunshine"
    };
    private static string[] KBRows = ["qwertyuiop", "asdfghjkl", "zxcvbnm", "1234567890"];
    static public bool PassLength(string pass)
    {
        if (pass.Length > 8)
        {
            return true;
        }
        return false;
    }
    static public bool LowerCase(string pass)
    {
        foreach (char c in pass)
        {
            if (char.IsLower(c))
            {
                return true;
            }
        }
        return false;
    }
    static public bool UpperCase(string pass)
    {
        foreach (char c in pass)
        {
            if (char.IsUpper(c))
            {
                return true;
            }
        }
        return false;
    }
    static public bool Special(string pass)
    {
        foreach (char c in pass)
        {
            if (SpecialChars.Contains(c))
            {
                return true;
            }
        }
        return false;
    }
    static public bool Digits(string pass)
    {
        foreach (char c in pass)
        {
            if (DigitsChars.Contains(c))
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsCommon(string pass)
    {
        if (CommonPass.Contains(pass))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsSeq(string pass, int seqlen = 4)
    {
        string lowcase = pass.ToLower();
        foreach (string row in KBRows)
        {
            string reverse = new string(row.Reverse().ToArray());
            for (int i = 0; i <= lowcase.Length - seqlen; i++)
            {
                string sub = lowcase.Substring(i, seqlen);
                if (row.Contains(sub) || reverse.Contains(sub))
                {
                    return true;
                }
            }
        }
        return false;
    }
}