﻿using lab3;

string engText = "Eliseev Vadim Olegovich";
string engKey = "Baby Baras";
PermutationsCipher cipher = new PermutationsCipher(engKey);
engText = cipher.Encrypt(engText);
Console.WriteLine("Зашифрованный текст на английском:");
Console.WriteLine(engText);
engText = cipher.Decrypt(engText);
Console.WriteLine("Расшифрованный текст на английском:");
Console.WriteLine(engText);
string rusText = "Елисеев Вадим Олегович";
string rusKey = "Дарт Барас";
cipher.Key = rusKey;
rusText = cipher.Encrypt(rusText);
Console.WriteLine("Зашифрованный текст на русском:");
Console.WriteLine(rusText);
rusText = cipher.Decrypt(rusText);
Console.WriteLine("Расшифрованный текст на русском:");
Console.WriteLine(rusText);
