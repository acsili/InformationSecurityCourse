using System;

namespace InformationSecurity.CaesarСipher;

internal static class CaesarCipherEncrypter
{
    /// <summary>
    /// Зашифровать текст.
    /// </summary>
    /// <param name="step"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string EncryptString(int step, string text)
    => string.Join("", text.ToLower().Select(x => (char)(x + step > 122 ? x + step - 'z' + 'a' - 1 : x + step)));

    /// <summary>
    /// Расшифровать текст.
    /// </summary>
    /// <param name="step"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string DecryptString(int step, string text)
    => string.Join("", text.ToLower().Select(x => (char)(x - step < 97 ? x - step + 'z' - 'a' + 1 : x - step)));

    /// <summary>
    /// Взломать шифр. 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string HackCipher(string text)
    {
        var mostOftenLetter = text.ToLower().GroupBy(x => x).OrderBy(x => x.Count()).Last().Key; 
        return DecryptString(Math.Abs(mostOftenLetter - 'e'), text);
    }

}
