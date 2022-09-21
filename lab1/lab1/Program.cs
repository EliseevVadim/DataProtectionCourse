using lab1;
using lab1.Utils;

string rusText = "Елисеев Вадим Олегович";
CaesarCipher rusCipher = new CaesarCipher(Languages.Russian);
rusText = rusCipher.Encrypt(rusText, 7);
Console.WriteLine("Зашифрованный текст на русском:");
Console.WriteLine(rusText);
rusText = rusCipher.DecryptWithASpecificOffset(rusText, 7);
Console.WriteLine("Расшифрованный текст на русском:");
Console.WriteLine(rusText);
Console.WriteLine();
rusText = rusCipher.Encrypt(rusText, 7);
Console.WriteLine("Расшифровка ФИО на русском без указанного смещения:");
string[] rusTextPossibleAnswers = rusCipher.DecryptWithUnknownOffset(rusText);
for (int i = 0; i < rusTextPossibleAnswers.Length; i++)
{
    Console.WriteLine($"Смещение {i + 1} - результат: {rusTextPossibleAnswers[i]}");
}
Console.WriteLine();
string engText = "Eliseev Vadim Olegovich";
CaesarCipher engCipher = new CaesarCipher(Languages.English);
engText = engCipher.Encrypt(engText, 7);
Console.WriteLine("Зашифрованный текст на английском:");
Console.WriteLine(engText);
engText = engCipher.DecryptWithASpecificOffset(engText, 7);
Console.WriteLine("Расшифрованный текст на английском:");
Console.WriteLine(engText);
engText = engCipher.Encrypt(engText, 7);
Console.WriteLine();
Console.WriteLine("Расшифровка ФИО на английском без указанного смещения:");
string[] engTextPossibleAnswers = engCipher.DecryptWithUnknownOffset(engText);
for (int i = 0; i < engTextPossibleAnswers.Length; i++)
{
    Console.WriteLine($"Смещение {i + 1} - результат: {engTextPossibleAnswers[i]}");
}
