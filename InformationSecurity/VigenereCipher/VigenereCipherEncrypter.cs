using System;
using System.Text;

namespace InformationSecurity.VigenereCipher;

public static class VigenereCipherEncrypter
{
    /// <summary>
    /// Квадрат Вижинера
    /// </summary>
    public static readonly char[,] VigenereSquare = new char[26, 26];

    static VigenereCipherEncrypter()
    {
        CreateSquare();
    }

    /// <summary>
    /// Создает квадрат Вижинера.
    /// </summary>
    private static void CreateSquare()
    {
        for (int i = 0; i < 26; i++)
            for (int j = i; j < 26 + i; j++)
                if (j < 26)
                    VigenereSquare[i, j - i] = (char)('a' + j);
                else
                    VigenereSquare[i, j - i] = (char)('a' + j - 26);
    }

    /// <summary>
    /// Создает полный ключ для исходного текста.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    private static string FullKey(string text, string key)
    {
        var res = key;

        while (res.Length < text.Length)
            res += res;

        return res[..text.Length];
    }

    /// <summary>
    /// Зашифровать текст.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string EncryptString(string text, string key)
    {
        var fullKey = FullKey(text, key);
        var result = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
            result.Append(VigenereSquare[text[i] - 'a', fullKey[i] - 'a']);

        return result.ToString();
    }

    /// <summary>
    /// Расшифровать текст.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string DecryptString(string text, string key)
    {
        var fullKey = FullKey(text, key);
        var result = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
            for (int j = 0; j < 27; j++)
                if (text[i] == VigenereSquare[j, fullKey[i] - 'a'])
                {
                    result.Append((char)(j + 'a'));
                    break;
                }

        return result.ToString();
    }
}

