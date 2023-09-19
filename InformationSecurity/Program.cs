
using InformationSecurity.CaesarСipher;

string text = "asdvbhesihqxzccbqegbwibewgkjeqbgwofiwnbegihbwieoiqgvnjmjknjansjqiwuhfewovdmxnjsdfz";

var strEn = CaesarCipherEncrypter.EncryptString(6, text);
var strDe = CaesarCipherEncrypter.DecryptString(6, strEn);

Console.WriteLine(strEn);
Console.WriteLine(strDe);
Console.WriteLine(CaesarCipherEncrypter.HackCipher(text));